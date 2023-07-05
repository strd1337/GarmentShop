using GarmentShop.Application.Common.Interfaces.Persistance.CommonRepositories;
using GarmentShop.Application.Common.Services;
using GarmentShop.Domain.AuthenticationAggregate.ValueObjects;
using GarmentShop.Domain.Common.Models;
using GarmentShop.Domain.Common.Outbox;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Newtonsoft.Json;

namespace GarmentShop.Infrastructure.Persistance.Repositories.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GarmentShopDbContext dbContext;
        private bool isDisposed;
        private readonly Dictionary<Type, object> repositories = new();
        private readonly IDateTimeProvider dateTimeProvider;

        public UnitOfWork(
            GarmentShopDbContext dbContext,
            IDateTimeProvider dateTimeProvider)
        {
            this.dbContext = dbContext;
            this.dateTimeProvider = dateTimeProvider;
        }

        public IGenericRepository<TEntity, TId> GetRepository<TEntity, TId>(
            bool hasCustomRepository = false)
                where TEntity : Entity<TId>
                where TId : ValueObject
        {
            if (hasCustomRepository)
            {
                var customRepository = dbContext
                    .GetService<IGenericRepository<TEntity, TId>>();

                if (customRepository is not null)
                {
                    return customRepository;
                }
            }

            var type = typeof(TEntity);
            if (!repositories.ContainsKey(type))
            {
                repositories[type] = new GenericRepository<TEntity, TId>(dbContext);
            }

            return (IGenericRepository<TEntity, TId>)repositories[type];
        }

        public int SaveChanges()
        {
            return dbContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync(
            CancellationToken cancellationToken)
        {
            ConvertDomainEventsToOutboxMessages<AuthenticationId>();

            return await dbContext.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                if (disposing)
                {
                    repositories?.Clear();
                    dbContext.Dispose();
                }
            }
            isDisposed = true;
        }

        private void ConvertDomainEventsToOutboxMessages<TId>()
            where TId : ValueObject
        {
            /*var outboxMessages = dbContext.ChangeTracker
                .Entries<AggregateRoot<TId>>()
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
                    OccurredOnUtc = dateTimeProvider.UtcNow
                })
                .ToList();
            */
            dbContext.Set<OutboxMessage>().AddRange(/*outboxMessages*/);
        }
    }
}
