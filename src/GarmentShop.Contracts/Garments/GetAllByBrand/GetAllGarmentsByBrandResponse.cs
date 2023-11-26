using GarmentShop.Contracts.Garments.Dtos;

namespace GarmentShop.Contracts.Garments.GetAllByBrand
{
    public record GetAllGarmentsByBrandResponse(
        ICollection<GarmentDto> Garments);
}
