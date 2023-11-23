using GarmentShop.Application.Brands.Commands.Create;
using GarmentShop.Application.Brands.Commands.Delete;
using GarmentShop.Application.Brands.Commands.Update;
using GarmentShop.Application.Brands.Queries;
using GarmentShop.Contracts.Brands.Create;
using GarmentShop.Contracts.Brands.Delete;
using GarmentShop.Contracts.Brands.GetAll;
using GarmentShop.Contracts.Brands.Update;
using GarmentShop.Domain.UserAggregate.Enums;
using GarmentShop.Infrastructure.Auth.Roles;
using GarmentShop.Presentation.Controllers.Common;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GarmentShop.Presentation.Controllers.Brand
{
    //[Authorize]
    //[HasRole(RoleType.Admin)]
    [Route("brands")]
    public class BrandController : ApiController
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public BrandController(
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
            var request = new GetAllBrandsRequest();

            var query = mapper.Map<GetAllBrandsQuery>(request);

            var brandResult = await mediator
                .Send(query, cancellationToken);

            return brandResult.Match(
                brandResult => Ok(
                    mapper.Map<GetAllBrandsResponse>(brandResult)),
                errors => Problem(errors));
        }

        [HttpPost]
        public async Task<IActionResult> Create(
           CreateBrandRequest request,
           CancellationToken cancellationToken)
        {
            var command = mapper.Map<CreateBrandCommand>(request);

            var brandResult = await mediator
                .Send(command, cancellationToken);

            return brandResult.Match(
                brandResult => Ok(
                    mapper.Map<CreateBrandResponse>(brandResult)),
                errors => Problem(errors));
        }

        [HttpPut]
        public async Task<IActionResult> Update(
            UpdateBrandRequest request,
            CancellationToken cancellationToken)
        {
            var command = mapper.Map<UpdateBrandCommand>(request);

            var brandResult = await mediator
                .Send(command, cancellationToken);

            return brandResult.Match(
                brandResult => Ok(
                    mapper.Map<UpdateBrandResponse>(brandResult)),
                errors => Problem(errors));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(
            DeleteBrandRequest request,
            CancellationToken cancellationToken)
        {
            var command = mapper.Map<DeleteBrandCommand>(request);

            var brandResult = await mediator
                .Send(command, cancellationToken);

            return brandResult.Match(
                brandResult => Ok(
                    mapper.Map<DeleteBrandResponse>(brandResult)),
                errors => Problem(errors));
        }
    }
}
