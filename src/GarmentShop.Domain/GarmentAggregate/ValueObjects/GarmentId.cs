using GarmentShop.Domain.Common.Models;

namespace GarmentShop.Domain.GarmentAggregate.ValueObjects
{
    public sealed class GarmentId : ValueObject
    {
        public Guid Value { get; }

        private GarmentId(Guid value)
        {
            Value = value;
        }

        public static GarmentId CreateUnique() => new(Guid.NewGuid());

        public static GarmentId Create(Guid value)
            => new GarmentId(value);

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

#pragma warning disable CS8618
        private GarmentId()
        {
        }
#pragma warning restore CS8618
    }
}
