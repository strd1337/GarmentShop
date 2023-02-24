using GarmentShop.Domain.Common.Events;

namespace GarmentShop.Domain.Events
{
    public abstract record DomainEvent(Guid Id) : IDomainEvent;
}
