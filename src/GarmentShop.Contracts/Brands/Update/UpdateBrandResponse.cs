namespace GarmentShop.Contracts.Brands.Update
{
    public record UpdateBrandResponse(
        Guid BrandId,
        string Name,
        string Description);
}
