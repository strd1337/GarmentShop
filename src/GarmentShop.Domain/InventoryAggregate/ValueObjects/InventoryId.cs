using GarmentShop.Domain.Models;

namespace GarmentShop.Domain.InventoryAggregate.ValueObjects
{
    public sealed class InventoryId : ValueObject
    {
        public Guid Value { get; }

        private InventoryId(Guid value)
        {
            Value = value;
        }
        
        public static InventoryId CreateUnique() => new(Guid.NewGuid());

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
