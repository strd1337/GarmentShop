namespace GarmentShop.Domain.Events.Brand
{
    public record BrandUpdatedEvent(
        Guid Id,
        Guid BrandId,
        string Name,
        string Description) : DomainEvent(Id);
}
