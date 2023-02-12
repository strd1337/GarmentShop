using GarmentShop.Application.Users.Queries.GetUserInfo;
using GarmentShop.Contracts.Users;
using GarmentShop.Presentation.Controllers.Common;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GarmentShop.Presentation.Controllers.User 
{
    [Route("user")]
    //[Authorize]
    public class UserController : ApiController
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;
         
        public UserController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }
           
        [HttpGet("info")] 
        public async Task<IActionResult> GetUserInfoById(Guid id) 
        {
            var command = mapper.Map<GetUserInfoQuery>(id);

            var result = await mediator.Send(command);

            return result.Match(
                result => Ok(mapper.Map<GetUserInfoResponse>(result)),
                errors => Problem(errors));
        }
    }
}
