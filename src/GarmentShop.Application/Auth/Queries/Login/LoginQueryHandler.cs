using ErrorOr;
using GarmentShop.Application.Common.Interfaces.Auth;
using GarmentShop.Application.Auth.Common;
using GarmentShop.Domain.Common.Errors;
using GarmentShop.Application.Common.CQRS;
using GarmentShop.Application.Common.Interfaces.Persistance.CommonRepositories;

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
            var user = await unitOfWork.AuthenticationRepository.GetByEmail(query.Email);

            if (user is null ||
                !BCrypt.Net.BCrypt.Verify(query.Password, user.PasswordHash))
            {
                return Errors.Authentication.InvalidCredentials;
            }

            var token = jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token);
        }
    }
}
