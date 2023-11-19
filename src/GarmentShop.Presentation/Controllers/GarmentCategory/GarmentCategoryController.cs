using GarmentShop.Application.GarmentCategories.Queries;
using GarmentShop.Contracts.GarmentCategories.GetAll;
using GarmentShop.Presentation.Controllers.Common;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GarmentShop.Presentation.Controllers.GarmentCategory
{
    [Route("garmentcategories")]
    public class GarmentCategoryController : ApiController
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public GarmentCategoryController(
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
            var request = new GetAllGarmentCategoriesRequest();

            var query = mapper.Map<GetAllGarmentCategoriesQuery>(request);

            var categoryResult = await mediator
                .Send(query, cancellationToken);

            return categoryResult.Match(
                categoryResult => Ok(
                    mapper.Map<GetAllGarmentCategoriesResponse>(categoryResult)),
                errors => Problem(errors));
        }
    }
}
