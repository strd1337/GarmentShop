using ErrorOr;
using GarmentShop.Application.Common.CQRS;
using GarmentShop.Application.Common.Interfaces.Persistance.CommonRepositories;
using GarmentShop.Application.GarmentCategories.Common;
using GarmentShop.Domain.GarmentCategoryAggregate;
using GarmentShop.Domain.GarmentCategoryAggregate.ValueObjects;

namespace GarmentShop.Application.GarmentCategories.Queries
{
    public class GetAllGarmentCategoriesHandler
        : IQueryHandler<GetAllGarmentCategoriesQuery, GetAllGarmentCategoriesResult>
    {
        private readonly IUnitOfWork unitOfWork;
        
        public GetAllGarmentCategoriesHandler(
            IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<GetAllGarmentCategoriesResult>> Handle(
            GetAllGarmentCategoriesQuery query,
            CancellationToken cancellationToken)
        {
            var categories = await unitOfWork
                .GetRepository<GarmentCategory, GarmentCategoryId>()
                .GetAllAsync(cancellationToken);

            return new GetAllGarmentCategoriesResult(categories.ToList());
        }
    }
}
