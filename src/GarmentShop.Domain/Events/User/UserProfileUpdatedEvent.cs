namespace GarmentShop.Domain.Events.User
{
    public sealed record UserProfileUpdatedEvent(
        Guid Id,
        Guid UserId,
        string FirstName,
        string LastName,
        string PhoneNumber,
        string Address,
        string City,
        string ZipCode,
        string Country) : DomainEvent(Id);
}