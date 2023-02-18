using ErrorOr;
using GarmentShop.Application.Common.Interfaces.Auth;
using GarmentShop.Domain.Common.Errors;
using GarmentShop.Application.Auth.Common;
using GarmentShop.Domain.AuthenticationAggregate;
using GarmentShop.Domain.UserAggregate;
using GarmentShop.Domain.UserAggregate.ValueObjects;
using GarmentShop.Domain.UserAggregate.Enums;
using GarmentShop.Application.Common.CQRS;
using GarmentShop.Application.Common.Interfaces.Persistance.CommonRepositories;

namespace GarmentShop.Application.Auth.Commands.Register
{
    public class RegisterCommandHandler :
        ICommandHandler<RegisterCommand, AuthenticationResult>
    {
        private readonly IJwtTokenGenerator jwtTokenGenerator;
        private readonly IUnitOfWork unitOfWork;

        public RegisterCommandHandler(
            IJwtTokenGenerator jwtTokenGenerator, 
            IUnitOfWork unitOfWork)
        {
            this.jwtTokenGenerator = jwtTokenGenerator;
            this.unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(
            RegisterCommand command,  
            CancellationToken cancellationToken)
        {
            if (await unitOfWork.AuthenticationRepository
                .GetByEmail(command.Email) is not null)
            {
                return Errors.User.DuplicateEmail;
            }

            var role = await unitOfWork.RoleRepository
                .FindByNameAsync(
                    Enum.GetName(typeof(RoleType), RoleType.Customer)!,
                    cancellationToken);

            var user = User.Create(UserDetailInformation.CreateNew());

            await unitOfWork.UserRepository.AddRoleAsync(user, role!);

            await unitOfWork.UserRepository.AddAsync(user, cancellationToken);

            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            string passwordHash = BCrypt.Net.BCrypt
                .HashPassword(command.Password, salt);

            var registeringUser = Authentication.Create(
                command.UserName,
                command.Email,
                passwordHash,
                salt,
                user.Id); 

            await unitOfWork.AuthenticationRepository
                .AddAsync(registeringUser, cancellationToken);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            var token = jwtTokenGenerator.GenerateToken(registeringUser);

            return new AuthenticationResult(
                registeringUser,
                token);
        }
    }
}
