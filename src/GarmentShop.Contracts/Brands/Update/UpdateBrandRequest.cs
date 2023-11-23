namespace GarmentShop.Contracts.Brands.Update
{
    public record UpdateBrandRequest(
        Guid BrandId,
        string Name,
        string Description);
}
