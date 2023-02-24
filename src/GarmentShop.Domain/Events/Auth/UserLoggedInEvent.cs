namespace GarmentShop.Domain.Events.Auth
{
    public sealed record UserLoggedInEvent(
        Guid Id,
        Guid AuthId,
        Guid UserId) : DomainEvent(Id);
}
