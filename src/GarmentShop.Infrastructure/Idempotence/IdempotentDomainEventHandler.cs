using GarmentShop.Domain.Common.Events;
using GarmentShop.Domain.Common.Outbox;
using GarmentShop.Domain.Events;
using GarmentShop.Infrastructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GarmentShop.Infrastructure.Idempotence
{
    public sealed class IdempotentDomainEventHandler<TDomainEvent>
        : IDomainEventHandler<TDomainEvent>
            where TDomainEvent : DomainEvent
    {
        private readonly INotificationHandler<TDomainEvent> decorated;
        private readonly GarmentShopDbContext dbContext;

        public IdempotentDomainEventHandler(
            INotificationHandler<TDomainEvent> decorated,
            GarmentShopDbContext dbContext)
        {
            this.decorated = decorated;
            this.dbContext = dbContext;
        }

        public async Task Handle(
            TDomainEvent notification, 
            CancellationToken cancellationToken)
        {
            string consumer = decorated.GetType().Name;

            if (await dbContext
                .Set<OutboxMessageConsumer>()
                .AnyAsync(o => o.Id == notification.Id &&
                            o.Name == consumer,
                          cancellationToken))
            {
                return;
            }

            await decorated.Handle(notification, cancellationToken);

            dbContext
                .Set<OutboxMessageConsumer>()
                .Add(new OutboxMessageConsumer
                {
                    Id = notification.Id,
                    Name = consumer
                });

            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
