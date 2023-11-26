using GarmentShop.Application.Garments.Commands.Create;
using GarmentShop.Application.Garments.Commands.Delete;
using GarmentShop.Application.Garments.Queries;
using GarmentShop.Contracts.Garments.Create;
using GarmentShop.Contracts.Garments.Delete;
using GarmentShop.Contracts.Garments.GetAllByBrand;
using GarmentShop.Domain.UserAggregate.Enums;
using GarmentShop.Infrastructure.Auth.Roles;
using GarmentShop.Presentation.Controllers.Common;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GarmentShop.Presentation.Controllers.Garment
{
    [Authorize]
    [Route("garments")]
    public class GarmentController : ApiController
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public GarmentController(
            IMediator mediator,
            IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpGet("{brandName}")]
        public async Task<IActionResult> GetAllByBrand(
            string brandName,
            CancellationToken cancellationToken)
        {
            var request = new GetAllGarmentsByBrandRequest(brandName);

            var query = mapper.Map<GetAllGarmentsByBrandQuery>(request);

            var garmentResult = await mediator
                .Send(query, cancellationToken);

            return garmentResult.Match(
                garmentResult => Ok(
                    mapper.Map<GetAllGarmentsByBrandResponse>(garmentResult)),
                errors => Problem(errors));
        }

        [HasRole(RoleType.Admin)]
        [HttpPost]
        public async Task<IActionResult> Create(
           CreateGarmentRequest request,
           CancellationToken cancellationToken)
        {
            var command = mapper.Map<CreateGarmentCommand>(request);

            var garmentResult = await mediator
                .Send(command, cancellationToken);

            return garmentResult.Match(
                garmentResult => Ok(
                    mapper.Map<CreateGarmentResponse>(garmentResult)),
                errors => Problem(errors));
        }

        [HasRole(RoleType.Admin)]
        [HttpDelete]
        public async Task<IActionResult> Delete(
           DeleteGarmentRequest request,
           CancellationToken cancellationToken)
        {
            var command = mapper.Map<DeleteGarmentCommand>(request);

            var garmentResult = await mediator
                .Send(command, cancellationToken);

            return garmentResult.Match(
                garmentResult => Ok(
                    mapper.Map<DeleteGarmentResponse>(garmentResult)),
                errors => Problem(errors));
        }
    }
}
