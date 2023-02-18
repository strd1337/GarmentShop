using GarmentShop.Domain.AuthenticationAggregate.ValueObjects;
using GarmentShop.Domain.Common.Events;
using GarmentShop.Domain.UserAggregate.ValueObjects;

namespace GarmentShop.Domain.Events
{
    public sealed record UserRegisteredEvent(
        AuthenticationId AuthId, UserId UserId) : IDomainEvent
    {
    }
}