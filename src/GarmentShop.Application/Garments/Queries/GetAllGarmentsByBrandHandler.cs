using ErrorOr;
using GarmentShop.Application.Common.CQRS;
using GarmentShop.Application.Common.Interfaces.Persistance.CommonRepositories;
using GarmentShop.Application.Garments.Common;
using GarmentShop.Domain.BrandAggregate;
using GarmentShop.Domain.BrandAggregate.ValueObjects;
using GarmentShop.Domain.GarmentAggregate;
using GarmentShop.Domain.GarmentAggregate.ValueObjects;
using GarmentShop.Domain.Common.Errors;

namespace GarmentShop.Application.Garments.Queries
{
    public class GetAllGarmentsByBrandHandler
        : IQueryHandler<GetAllGarmentsByBrandQuery, GetAllGarmentsByBrandResult>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetAllGarmentsByBrandHandler(
            IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<GetAllGarmentsByBrandResult>> Handle(
            GetAllGarmentsByBrandQuery query,
            CancellationToken cancellationToken)
        {
            Brand? brand = await unitOfWork
                .GetRepository<Brand, BrandId>()
                .FirstOrDefaultAsync(
                    x => x.Name.ToLower().Equals(query.BrandName.ToLower()),
                    cancellationToken);
            
            if (brand is null)
            {
                return Errors.Brand.NotFound;
            }

            var garments = unitOfWork
                .GetRepository<Garment, GarmentId>()
                .GetWhere(x => x.BrandId == brand.Id);

            return new GetAllGarmentsByBrandResult(garments.ToList());
        }
    }
}
