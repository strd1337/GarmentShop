using GarmentShop.Domain.Models;

namespace GarmentShop.Domain.BrandAggregate.ValueObjects
{
    public sealed class BrandId : ValueObject
    {
        public Guid Value { get; }

        private BrandId(Guid value)
        {
            Value = value;
        }

        public static BrandId CreateUnique() => new(Guid.NewGuid());

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
