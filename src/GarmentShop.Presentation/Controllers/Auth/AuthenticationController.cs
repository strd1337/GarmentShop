﻿using GarmentShop.Application.Auth.Commands.ChangePassword;
using GarmentShop.Application.Auth.Commands.Register;
using GarmentShop.Application.Auth.Queries.Login;
using GarmentShop.Contracts.Authentication;
using GarmentShop.Domain.Common.Errors;
using GarmentShop.Presentation.Controllers.Common;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GarmentShop.Presentation.Controllers.Auth
{
    [Route("auth")]
    public class AuthenticationController : ApiController
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public AuthenticationController(
            IMediator mediator, 
            IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }
        
        [HttpPost("register")]
        public async Task<IActionResult> Register(
            RegisterRequest request,
            CancellationToken cancellationToken)
        {
            var command = mapper.Map<RegisterCommand>(request);

            var authResult = await mediator.Send(command, cancellationToken);

            return authResult.Match(
                authResult => Ok(mapper.Map<AuthenticationResponse>(authResult)),
                errors => Problem(errors));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(
            LoginRequest request,
            CancellationToken cancellationToken)
        {
            var query = mapper.Map<LoginQuery>(request);

            var authResult = await mediator.Send(query, cancellationToken);
            
            if (authResult.IsError && 
                authResult.FirstError == Errors.Authentication.InvalidCredentials)
            {
                return Problem(
                    statusCode: StatusCodes.Status401Unauthorized,
                    title: authResult.FirstError.Description);
            }

            return authResult.Match(
                authResult => Ok(mapper.Map<AuthenticationResponse>(authResult)),
                errors => Problem(errors));
        }

        [Authorize]
        [HttpPost("changepassword")]
        public async Task<IActionResult> ChangePassword(
            ChangePasswordRequest request,
            CancellationToken cancellationToken)
        {
            var command = mapper.Map<ChangePasswordCommand>(request);

            var authResult = await mediator
                .Send(command, cancellationToken);

            return authResult.Match(
                authResult => Ok(mapper
                    .Map<AuthenticationResponse>(authResult)),
                errors => Problem(errors));
        }
    }
}
