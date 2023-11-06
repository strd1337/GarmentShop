using ErrorOr;
using GarmentShop.Application.Auth.Common;
using GarmentShop.Application.Common.CQRS;
using GarmentShop.Application.Common.Interfaces.Auth;
using GarmentShop.Domain.Common.Errors;
using GarmentShop.Application.Common.Interfaces.Persistance.CommonRepositories;
using GarmentShop.Domain.AuthenticationAggregate;
using GarmentShop.Domain.AuthenticationAggregate.ValueObjects;
using GarmentShop.Application.Common.Interfaces.Persistance.UserRepositories;
using GarmentShop.Domain.UserAggregate.ValueObjects;
using GarmentShop.Domain.UserAggregate;
using GarmentShop.Domain.Events.Auth;

namespace GarmentShop.Application.Auth.Commands.ChangePassword
{
    public class ChangePasswordHandler :
        ICommandHandler<ChangePasswordCommand, AuthenticationResult>
    {
        private readonly IJwtTokenGenerator jwtTokenGenerator;
        private readonly IUnitOfWork unitOfWork;

        public ChangePasswordHandler(
        IJwtTokenGenerator jwtTokenGenerator,
        IUnitOfWork unitOfWork)
        {
            this.jwtTokenGenerator = jwtTokenGenerator;
            this.unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(
            ChangePasswordCommand command,
            CancellationToken cancellationToken)
        {
            var authUser = await unitOfWork
                .GetRepository<Authentication, AuthenticationId>()
                .FirstOrDefaultAsync(
                    x => x.UserName == command.UserName,
                    cancellationToken);

            if (authUser is null)
            {
                return Errors.User.NotFound;
            }

            if (!BCrypt.Net.BCrypt.Verify(
                command.CurrentPassword, authUser.PasswordHash))
            {
                return Errors.Authentication.InvalidOldPassword;
            }

            string newSalt = BCrypt.Net.BCrypt.GenerateSalt();
            string newPasswordHash = BCrypt.Net.BCrypt
                .HashPassword(command.NewPassword, newSalt);

            authUser.SetPassword(newPasswordHash, newSalt);

            authUser.RaiseDomainEvent(new UserChangedPasswordEvent(
                Guid.NewGuid(),
                authUser.Id.Value,
                authUser.UserId.Value));

            await unitOfWork.SaveChangesAsync(cancellationToken);

            var userRepository = unitOfWork.GetRepository<User, UserId>(true)
                as IUserRepository;

            var user = await userRepository!
                .FindByIdAsync(authUser.UserId, cancellationToken);

            var token = jwtTokenGenerator.GenerateToken(authUser, user!);

            return new AuthenticationResult(
                authUser.Id.Value, 
                authUser, 
                token);
        }
    }
}