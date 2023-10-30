namespace GarmentShop.Domain.Events.User
{
    public sealed record UserProfileViewedEvent(
       Guid Id,
       Guid AuthId,
       Guid UserId) : DomainEvent(Id);
}
