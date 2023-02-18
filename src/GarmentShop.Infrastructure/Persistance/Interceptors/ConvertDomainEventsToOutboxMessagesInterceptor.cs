using GarmentShop.Domain.Common.Models;
using GarmentShop.Domain.Common.Outbox;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Newtonsoft.Json;

namespace GarmentShop.Infrastructure.Persistance.Interceptors
{
    public sealed class ConvertDomainEventsToOutboxMessagesInterceptor<TAggregateRoot, TId> 
        : SaveChangesInterceptor
            where TAggregateRoot : AggregateRoot<TId>
            where TId : notnull
    {
        public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(
            DbContextEventData eventData, 
            InterceptionResult<int> result, 
            CancellationToken cancellationToken = default)
        {
            DbContext? dbContext = eventData.Context;

            if (dbContext is null)
            {
                return await base.SavingChangesAsync(eventData, result, cancellationToken);
            }

            var outboxMessages = dbContext.ChangeTracker
                .Entries<TAggregateRoot>()
                .Select(x => x.Entity)
                .SelectMany(aggregateRoot =>
                {
                    var domainEvents = aggregateRoot.GetDomainEvents();

                    aggregateRoot.ClearDomainEvents();

                    return domainEvents;
                })
                .Select(domainEvent => new OutboxMessage
                {
                    Id = Guid.NewGuid(),
                    Type = domainEvent.GetType().Name,
                    Content = JsonConvert.SerializeObject(
                        domainEvent,
                        new JsonSerializerSettings
                        {
                            TypeNameHandling = TypeNameHandling.All
                        }),
                    OccurredOnUtc = DateTime.UtcNow
                })
                .ToList();

            dbContext.Set<OutboxMessage>().AddRange(outboxMessages);

            return await base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}
