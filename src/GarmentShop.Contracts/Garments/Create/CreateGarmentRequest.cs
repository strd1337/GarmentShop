namespace GarmentShop.Contracts.Garments.Create
{
    public record CreateGarmentRequest(
        Guid BrandId,
        Guid GarmentTypeId,
        string Name,
        string Description,
        decimal Price,
        int Size,
        int Color,
        int Material,
        int AvailableQuantity);
}
