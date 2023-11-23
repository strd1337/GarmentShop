namespace GarmentShop.Domain.Events.Brand
{
    public record BrandCreatedEvent(
        Guid Id,
        Guid BrandId,
        string Name,
        string Description) : DomainEvent(Id);
}
