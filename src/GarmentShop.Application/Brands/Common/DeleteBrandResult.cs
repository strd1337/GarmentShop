namespace GarmentShop.Application.Brands.Common
{
    public record DeleteBrandResult(
        Guid BrandId,
        string Name,
        string Description);
}
