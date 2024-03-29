﻿using GarmentShop.Domain.Common.Models;

namespace GarmentShop.Domain.GarmentTypeAggregate.ValueObjects
{
    public sealed class GarmentTypeId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        private GarmentTypeId(Guid value)
        {
            Value = value;
        }

        public static GarmentTypeId CreateUnique() => new(Guid.NewGuid());

        public static GarmentTypeId Create(Guid value)
            => new GarmentTypeId(value);

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

#pragma warning disable CS8618
        private GarmentTypeId()
        {
        }
#pragma warning restore CS8618
    }
}
