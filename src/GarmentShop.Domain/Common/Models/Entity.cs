﻿using GarmentShop.Domain.Common.Events;

namespace GarmentShop.Domain.Common.Models
{
    public abstract class Entity<TId> : IEquatable<Entity<TId>>, IHasDomainEvents
        where TId : ValueObject
    {
        private readonly List<IDomainEvent> domainEvents = new();

        public TId Id { get; protected set; }
        public DateTime CreatedDate { get; protected set; } = DateTime.Now;
        public DateTime ModifiedDate { get; protected set; } = DateTime.Now;
        
        public IReadOnlyList<IDomainEvent> GetDomainEvents() => domainEvents.ToList();

        protected Entity(TId id)
        {
            Id = id;
        }

        public override bool Equals(object? obj)
        {
            return obj is Entity<TId> entity && Id.Equals(entity.Id);
        }

        public bool Equals(Entity<TId>? other)
        {
            return Equals((object?)other);
        }

        public static bool operator ==(Entity<TId> left, Entity<TId> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Entity<TId> left, Entity<TId> right)
        {
            return !Equals(left, right);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public void RaiseDomainEvent(IDomainEvent domainEvent)
        {
            domainEvents.Add(domainEvent);
        }

        public void ClearDomainEvents()
        {
            domainEvents.Clear();
        }

#pragma warning disable CS8618
        protected Entity()
        {
        }
#pragma warning restore CS8618
    }
}
