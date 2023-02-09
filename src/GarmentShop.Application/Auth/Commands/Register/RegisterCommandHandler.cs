using ErrorOr;
using MediatR;
using GarmentShop.Application.Common.Interfaces.Auth;
using GarmentShop.Application.Common.Interfaces.Persistance;
using GarmentShop.Domain.Common.Errors;
using GarmentShop.Application.Auth.Common;
using GarmentShop.Domain.AuthenticationAggregate;
using GarmentShop.Domain.Common.Constants;

namespace GarmentShop.Application.Auth.Commands.Register
{
    public class RegisterCommandHandler :
        IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator jwtTokenGenerator;
        private readonly IAuthenticationRepository authenticationRepository;

        public RegisterCommandHandler(
            IJwtTokenGenerator jwtTokenGenerator, 
            IAuthenticationRepository authenticationRepository)
        {
            this.jwtTokenGenerator = jwtTokenGenerator;
            this.authenticationRepository = authenticationRepository;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(
            RegisterCommand command,  
            CancellationToken cancellationToken)
        {
            if (authenticationRepository.FindUserByEmail(command.Email) is not null)
            {
                return Errors.User.DuplicateEmail;
            }

            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            string passwordHash = BCrypt.Net.BCrypt
                .HashPassword(command.Password, salt);

            var user = Authentication.Create(
                command.UserName,
                command.Email,
                passwordHash,
                salt,
                Role.Customer);

            authenticationRepository.CreateUser(user);

            var token = jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token);
        }
    }
}
