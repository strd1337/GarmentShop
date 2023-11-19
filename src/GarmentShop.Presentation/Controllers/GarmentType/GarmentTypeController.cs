using GarmentShop.Application.GarmentTypes.Queries;
using GarmentShop.Contracts.GarmentTypes.GetAll;
using GarmentShop.Presentation.Controllers.Common;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GarmentShop.Presentation.Controllers.GarmentType
{
    [Route("garmenttypes")]
    public class GarmentTypeController : ApiController
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public GarmentTypeController(
            IMediator mediator,
            IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
            CancellationToken cancellationToken)
        {
            var request = new GetAllGarmentTypesRequest();

            var query = mapper.Map<GetAllGarmentTypesQuery>(request);

            var typeResult = await mediator
                .Send(query, cancellationToken);

            return typeResult.Match(
              typeResult => Ok(
                  mapper.Map<GetAllGarmentTypesResponse>(typeResult)),
               errors => Problem(errors));
        }
    }
}