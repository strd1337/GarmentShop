using GarmentShop.Domain.GarmentAggregate.ValueObjects;
using GarmentShop.Domain.Models;

namespace GarmentShop.Domain.StockAggregate.ValueObjects
{
    public sealed class StockId : ValueObject
    {
        public Guid Value { get; }

        private StockId(Guid value)
        {
            Value = value;
        }

        public static StockId CreateUnique() => new(Guid.NewGuid());

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
