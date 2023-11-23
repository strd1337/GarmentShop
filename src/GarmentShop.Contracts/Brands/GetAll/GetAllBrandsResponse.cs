using GarmentShop.Contracts.Brands.Dtos;

namespace GarmentShop.Contracts.Brands.GetAll
{
    public record GetAllBrandsResponse(
        ICollection<BrandDto> Brands);
}
