using GarmentShop.Domain.Models;

namespace GarmentShop.Domain.SalesAggregate.ValueObjects
{
    public sealed class SaleId : ValueObject
    {
        public Guid Value { get; }

        private SaleId(Guid value)
        {
            Value = value;
        }

        public static SaleId CreateUnique() => new(Guid.NewGuid());

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
