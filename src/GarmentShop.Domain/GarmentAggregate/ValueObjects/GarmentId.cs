using GarmentShop.Domain.Models;

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
      
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
