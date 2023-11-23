using GarmentShop.Application.Common.Interfaces.Persistance.Brands;
using GarmentShop.Domain.BrandAggregate;
using GarmentShop.Domain.BrandAggregate.ValueObjects;
using GarmentShop.Infrastructure.Persistance.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace GarmentShop.Infrastructure.Persistance.Repositories.BrandAgg
{
    internal class BrandRepository
        :   GenericRepository<Brand, BrandId>,
            IBrandRepository
    {
        public BrandRepository(GarmentShopDbContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<bool> IsBrandNotUniqueAsync(
            string name,
            CancellationToken cancellationToken = default)
        {
            return await dbContext.Brands
                .AnyAsync(b => b.Name.Equals(name), cancellationToken);
        }
    }
}
