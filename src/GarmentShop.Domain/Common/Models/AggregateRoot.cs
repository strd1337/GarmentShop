using GarmentShop.Domain.Common.Events;

namespace GarmentShop.Domain.Common.Models
{
    public abstract class AggregateRoot<TId, TIdType> : Entity<TId>
        where TId : AggregateRootId<TIdType>
    {
        private readonly List<IDomainEvent> domainEvents = new();
        public new AggregateRootId<TIdType> Id { get; protected set; }

        protected AggregateRoot(TId id) 
        {
            Id =  id;
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
