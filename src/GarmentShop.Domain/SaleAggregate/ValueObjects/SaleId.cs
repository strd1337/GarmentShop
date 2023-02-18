using GarmentShop.Domain.Common.Models;

namespace GarmentShop.Domain.SaleAggregate.ValueObjects
{
    public sealed class SaleId : ValueObject
    {
        public Guid Value { get; }

        private SaleId(Guid value)
        {
            Value = value;
        }

        public static SaleId CreateUnique() => new(Guid.NewGuid());

        public static SaleId Create(Guid value)
            => new SaleId(value);

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

#pragma warning disable CS8618
        private SaleId()
        {
        }
#pragma warning restore CS8618
    }
}
