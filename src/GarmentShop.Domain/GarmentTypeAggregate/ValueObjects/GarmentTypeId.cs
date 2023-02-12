using GarmentShop.Domain.Models;

namespace GarmentShop.Domain.GarmentTypeAggregate.ValueObjects
{
    public sealed class GarmentTypeId : ValueObject
    {
        public Guid Value { get; }

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
