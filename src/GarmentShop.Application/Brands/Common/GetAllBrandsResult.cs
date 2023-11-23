using GarmentShop.Domain.BrandAggregate;

namespace GarmentShop.Application.Brands.Common
{
    public record GetAllBrandsResult(
        ICollection<Brand> Brands);
}
