using GarmentShop.Application.Services.Auth;
using GarmentShop.Contracts.Authentication;
using GarmentShop.Domain.Common.Errors;
using Microsoft.AspNetCore.Mvc;

namespace GarmentShop.Presentation.Controllers.Auth
{
    [Route("auth")]
    public class AuthenticationController : ApiController
    {
        private readonly IAuthenticationService authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            var authResult = authenticationService.Register(
                request.FirstName,
                request.LastName, 
                request.Email, 
                request.Password);

            return authResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                errors => Problem(errors));
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var authResult = authenticationService.Login(
                request.Email,
                request.Password);

            if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
            {
                return Problem(
                    statusCode: StatusCodes.Status401Unauthorized,
                    title: authResult.FirstError.Description);
            }

            return authResult.Match(
                 authResult => Ok(MapAuthResult(authResult)),
                errors => Problem(errors));
        }
         
        private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
        {
            return new AuthenticationResponse(
                authResult.User.Id,
                authResult.User.FirstName,
                authResult.User.LastName,
                authResult.User.Email,
                authResult.Token);
        }
    }
}
