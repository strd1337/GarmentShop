namespace GarmentShop.Contracts.Garments.Create
{
    public record CreateGarmentResponse(
        Guid GarmentId,
        Guid BrandId,
        Guid GarmentTypeId,
        string Name,
        string Description,
        decimal Price,
        string Size,
        string Color,
        string Material,
        int AvailableQuantity);
}
