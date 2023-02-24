using GarmentShop.Domain.Common.Events;

namespace GarmentShop.Domain.Common.Models
{
    public abstract class AggregateRoot<TId> : Entity<TId>
        where TId : notnull
    {
        private readonly List<IDomainEvent> domainEvents = new();

        protected AggregateRoot(TId id) : base(id)
        {
        }

        public void RaiseDomainEvent(IDomainEvent @event)
        {
            domainEvents.Add(@event);
        }

        public IReadOnlyCollection<IDomainEvent> GetDomainEvents()
            => domainEvents.ToList();

        public void ClearDomainEvents()
        {
            domainEvents.Clear();
        }

#pragma warning disable CS8618
        protected AggregateRoot()
        {
        }
#pragma warning restore CS8618
    }
}
