using MediatR;

namespace GarmentShop.Domain.Common.Events
{
    public interface IDomainEventHandler<in TEvent> 
        : INotificationHandler<TEvent>
            where TEvent : IDomainEvent
    { 
    }
}
