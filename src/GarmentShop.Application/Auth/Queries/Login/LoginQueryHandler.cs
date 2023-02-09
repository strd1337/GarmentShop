using ErrorOr;
using MediatR;
using GarmentShop.Application.Common.Interfaces.Auth;
using GarmentShop.Application.Common.Interfaces.Persistance;
using GarmentShop.Application.Auth.Common;
using GarmentShop.Domain.Common.Errors;

namespace GarmentShop.Application.Auth.Queries.Login
{
    public class LoginQueryHandler :
        IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator jwtTokenGenerator;
        private readonly IAuthenticationRepository authenticationRepository;

        public LoginQueryHandler(
            IJwtTokenGenerator jwtTokenGenerator,
            IAuthenticationRepository authenticationRepository)
        {
            this.jwtTokenGenerator = jwtTokenGenerator;
            this.authenticationRepository = authenticationRepository;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(
            LoginQuery query,
            CancellationToken cancellationToken)
        {
            var user = authenticationRepository.FindUserByEmail(query.Email);

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
