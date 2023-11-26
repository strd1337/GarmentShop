namespace GarmentShop.Domain.Events.Garment
{
    public record GarmentCreatedEvent(
        Guid Id,
        Guid GarmentId,
        Guid BrandId,
        Guid GarmentTypeId,
        string Name,
        string Description,
        decimal Price,
        string Size,
        string Color,
        string Material,
        int AvailableQuantity) : DomainEvent(Id);
}