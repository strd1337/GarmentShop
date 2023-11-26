namespace GarmentShop.Application.Garments.Common
{
    public record CreateGarmentResult(
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
