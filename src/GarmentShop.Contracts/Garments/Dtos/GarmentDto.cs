namespace GarmentShop.Contracts.Garments.Dtos
{
    public record GarmentDto(
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