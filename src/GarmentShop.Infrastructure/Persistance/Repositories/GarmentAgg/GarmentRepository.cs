using GarmentShop.Application.Common.Interfaces.Persistance.Garments;
using GarmentShop.Domain.GarmentAggregate;
using GarmentShop.Domain.GarmentAggregate.ValueObjects;
using GarmentShop.Infrastructure.Persistance.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace GarmentShop.Infrastructure.Persistance.Repositories.GarmentAgg
{
    public class GarmentRepository
        : GenericRepository<Garment, GarmentId>,
            IGarmentRepository
    {
        public GarmentRepository(GarmentShopDbContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<bool> IsGarmentNotUniqueAsync(
            string name,
            CancellationToken cancellationToken = default)
        {
            return await dbContext.Garments
                .AnyAsync(b =>
                    b.Name.ToLower().Equals(name.ToLowerInvariant()),
                    cancellationToken);
        }
    }
}
