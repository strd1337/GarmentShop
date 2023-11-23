namespace GarmentShop.Contracts.Brands.Create
{
    public record CreateBrandResponse(
        Guid BrandId,
        string Name,
        string Description);
}
