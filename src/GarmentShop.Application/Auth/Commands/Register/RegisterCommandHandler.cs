using ErrorOr;
using MediatR;
using GarmentShop.Application.Common.Interfaces.Auth;
using GarmentShop.Application.Common.Interfaces.Persistance;
using GarmentShop.Domain.Common.Errors;
using GarmentShop.Application.Auth.Common;
using GarmentShop.Domain.AuthenticationAggregate;
using GarmentShop.Domain.UserAggregate;
using GarmentShop.Domain.UserAggregate.ValueObjects;
using GarmentShop.Domain.UserAggregate.Entities;
using GarmentShop.Domain.UserAggregate.Enums;

namespace GarmentShop.Application.Auth.Commands.Register
{
    public class RegisterCommandHandler :
        IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator jwtTokenGenerator;
        private readonly IAuthenticationRepository authenticationRepository;
        private readonly IUserRepository userRepository;

        public RegisterCommandHandler(
            IJwtTokenGenerator jwtTokenGenerator, 
            IAuthenticationRepository authenticationRepository,
            IUserRepository userRepository)
        {
            this.jwtTokenGenerator = jwtTokenGenerator;
            this.authenticationRepository = authenticationRepository;
            this.userRepository = userRepository;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(
            RegisterCommand command,  
            CancellationToken cancellationToken)
        {
            if (authenticationRepository.FindUserByEmail(command.Email) is not null)
            {
                return Errors.User.DuplicateEmail;
            }

            var role = UserRole.Create("Customer", RoleType.Customer);
            
            role.AddPermission(Permission.Create("AddToCart", 
                PermissionType.AddToCart));
            role.AddPermission(Permission.Create("PlaceOrder", 
                PermissionType.PlaceOrder));
            role.AddPermission(Permission.Create("ViewOrderHistory", 
                PermissionType.ViewOrderHistory));
            role.AddPermission(Permission.Create("UpdateShippingAddress", 
                PermissionType.UpdateShippingAddress));

            var user = User.Create(UserDetailInformation.CreateNew());
            user.AddRole(role);

            userRepository.Create(user);

            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            string passwordHash = BCrypt.Net.BCrypt
                .HashPassword(command.Password, salt);

            var registeringUser = Authentication.Create(
                command.UserName,
                command.Email,
                passwordHash,
                salt,
                user.Id); 

            authenticationRepository.CreateUser(registeringUser);
        
            var token = jwtTokenGenerator.GenerateToken(registeringUser);

            return new AuthenticationResult(
                registeringUser,
                token);
        }
    }
}
