namespace GarmentShop.Contracts.Brands.Delete
{
    public record DeleteBrandResponse(
        Guid BrandId,
        string Name,
        string Description);
}
