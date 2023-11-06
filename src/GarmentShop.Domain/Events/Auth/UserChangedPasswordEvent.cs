namespace GarmentShop.Domain.Events.Auth
{
    public sealed record UserChangedPasswordEvent(
        Guid Id,
        Guid AuthId,
        Guid UserId) : DomainEvent(Id);
}
