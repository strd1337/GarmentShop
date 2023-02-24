namespace GarmentShop.Domain.Events.Auth
{
    public sealed record UserRegisteredEvent(
        Guid Id,
        Guid AuthId,
        Guid UserId) : DomainEvent(Id);
}