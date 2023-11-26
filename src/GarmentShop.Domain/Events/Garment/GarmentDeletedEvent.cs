namespace GarmentShop.Domain.Events.Garment
{
    public record GarmentDeletedEvent(
        Guid Id,
        Guid GarmentId,
        string Name) : DomainEvent(Id);
}