using ErrorOr;
using GarmentShop.Application.Common.Interfaces.Auth;
using GarmentShop.Application.Auth.Common;
using GarmentShop.Domain.Common.Errors;
using GarmentShop.Application.Common.CQRS;
using GarmentShop.Application.Common.Interfaces.Persistance.CommonRepositories;
using GarmentShop.Domain.AuthenticationAggregate.ValueObjects;
using GarmentShop.Domain.AuthenticationAggregate;
using GarmentShop.Domain.UserAggregate.ValueObjects;
using GarmentShop.Domain.UserAggregate;
using GarmentShop.Application.Common.Interfaces.Persistance.UserRepositories;

namespace GarmentShop.Application.Auth.Queries.Login
{
    public class LoginQueryHandler :
        IQueryHandler<LoginQuery, AuthenticationResult>
    {
        private readonly IJwtTokenGenerator jwtTokenGenerator;
        private readonly IUnitOfWork unitOfWork;

        public LoginQueryHandler(
            IJwtTokenGenerator jwtTokenGenerator,
            IUnitOfWork unitOfWork)
        {
            this.jwtTokenGenerator = jwtTokenGenerator;
            this.unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(
            LoginQuery query,
            CancellationToken cancellationToken)
        {
            var authUser = await unitOfWork
                .GetRepository<Authentication, AuthenticationId>()
                .FirstOrDefaultAsync(
                    x => x.Email == query.Email,
                    cancellationToken);

            if (authUser is null ||
                !BCrypt.Net.BCrypt.Verify(query.Password, authUser.PasswordHash))
            {
                return Errors.Authentication.InvalidCredentials;
            }

            var userRepository = unitOfWork.GetRepository<User, UserId>(true) 
                as IUserRepository;

            var user = await userRepository!
                .FindByIdAsync(authUser.UserId, cancellationToken);

            var token = jwtTokenGenerator.GenerateToken(authUser, user!);

            return new AuthenticationResult(
                authUser,
                token);
        }
    }
}
