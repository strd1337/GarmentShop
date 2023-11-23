using GarmentShop.Application.Common.Interfaces.Persistance.CommonRepositories;
using GarmentShop.Domain.BrandAggregate;
using GarmentShop.Domain.BrandAggregate.ValueObjects;

namespace GarmentShop.Application.Common.Interfaces.Persistance.Brands
{
    public interface IBrandRepository 
        : IGenericRepository<Brand, BrandId>
    {
        Task<bool> IsBrandNotUniqueAsync(string name,
            CancellationToken cancellationToken = default);
    }
}
