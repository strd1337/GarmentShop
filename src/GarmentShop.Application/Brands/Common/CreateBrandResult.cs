using GarmentShop.Domain.BrandAggregate;

namespace GarmentShop.Application.Brands.Common
{
    public record CreateBrandResult(
        Guid BrandId,
        string Name,
        string Description);
}
