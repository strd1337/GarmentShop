﻿using GarmentShop.Application.Users.Commands.UserProfileUpdate;
using GarmentShop.Application.Users.Queries;
using GarmentShop.Contracts.User.Profile;
using GarmentShop.Contracts.User.UpdateProfile;
using GarmentShop.Presentation.Controllers.Common;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GarmentShop.Presentation.Controllers.User
{
    [Authorize]
    [Route("user")]
    public class UserController : ApiController
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public UserController(
            IMediator mediator,
            IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpGet("profile")]
        public async Task<IActionResult> GetProfile(
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken)
        {
            var request = new UserProfileRequest(User.Identity!.Name!);

            var query = mapper.Map<UserProfileQuery>(request);

            var profileResult = await mediator
                .Send(query, cancellationToken);

            return profileResult.Match(
                profileResult => Ok(
                    mapper.Map<UserProfileResponse>(profileResult)),
                errors => Problem(errors));
        }

        [HttpPut("profile")]
        public async Task<IActionResult> UpdateProfile(
            UserProfileUpdateRequest request,
            CancellationToken cancellationToken)
        {
            var command = mapper.Map<UserProfileUpdateCommand>(request);
            
            var profileUpdateResult = await mediator
                .Send(command, cancellationToken);

            return profileUpdateResult.Match(
                profileUpdateResult => Ok(
                    mapper.Map<UserProfileUpdateResponse>(profileUpdateResult)),
                errors => Problem(errors));
        }
    }
}
