using ErrorOr;
using GarmentShop.Application.Brands.Common;
using GarmentShop.Application.Common.CQRS;
using GarmentShop.Application.Common.Interfaces.Persistance.CommonRepositories;
using GarmentShop.Domain.BrandAggregate;
using GarmentShop.Domain.BrandAggregate.ValueObjects;

namespace GarmentShop.Application.Brands.Queries
{
    public class GetAllBrandsHandler
        : IQueryHandler<GetAllBrandsQuery, GetAllBrandsResult>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetAllBrandsHandler(
            IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<GetAllBrandsResult>> Handle(
            GetAllBrandsQuery query,
            CancellationToken cancellationToken)
        {
            var brands = await unitOfWork
                .GetRepository<Brand, BrandId>()
                .GetAllAsync(cancellationToken);

            return new GetAllBrandsResult(brands.ToList());
        }
    }
}
