using GarmentShop.Domain.GarmentAggregate;

namespace GarmentShop.Application.Garments.Common
{
    public record GetAllGarmentsByBrandResult(
        ICollection<Garment> Garments);
}
