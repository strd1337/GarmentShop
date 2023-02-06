using ErrorOr;
using MediatR;
using GarmentShop.Application.Common.Interfaces.Auth;
using GarmentShop.Application.Common.Interfaces.Persistance;
using GarmentShop.Domain.Common.Errors;
using GarmentShop.Domain.Entities;
using GarmentShop.Application.Auth.Common;

namespace GarmentShop.Application.Auth.Commands.Register
{
    public class RegisterCommandHandler :
        IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator jwtTokenGenerator;
        private readonly IUserRepository userRepository;

        public RegisterCommandHandler(
            IJwtTokenGenerator jwtTokenGenerator, 
            IUserRepository userRepository)
        {
            this.jwtTokenGenerator = jwtTokenGenerator;
            this.userRepository = userRepository;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(
            RegisterCommand command,  
            CancellationToken cancellationToken)
        {
            if (userRepository.GetUserByEmail(command.Email) is not null)
            {
                return Errors.User.DuplicateEmail;
            }

            var user = new User
            {
                FirstName= command.FirstName,
                LastName= command.LastName,
                Email= command.Email,
                Password= command.Password
            };

            userRepository.Add(user);

            var token = jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token);
        }
    }
}
