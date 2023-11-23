namespace GarmentShop.Domain.Events.Brand
{
    public record BrandDeletedEvent(
        Guid Id,
        Guid BrandId,
        string Name,
        string Description) : DomainEvent(Id);
}
