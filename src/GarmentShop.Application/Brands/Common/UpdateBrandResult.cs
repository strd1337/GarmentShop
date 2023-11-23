namespace GarmentShop.Application.Brands.Common
{
    public record UpdateBrandResult(
        Guid BrandId,
        string Name,
        string Description);
}
