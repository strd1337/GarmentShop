using GarmentShop.Application.Common.Interfaces.Persistance.CommonRepositories;
using GarmentShop.Domain.BrandAggregate.ValueObjects;
using GarmentShop.Domain.GarmentAggregate;
using GarmentShop.Domain.GarmentAggregate.ValueObjects;

namespace GarmentShop.Application.Common.Interfaces.Persistance.Garments
{
    public interface IGarmentRepository
        : IGenericRepository<Garment, GarmentId>
    {
        Task<bool> IsGarmentNotUniqueAsync(string name,
            CancellationToken cancellationToken = default);
    }
}
