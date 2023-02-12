using GarmentShop.Domain.Models;

namespace GarmentShop.Domain.SaleAggregate.ValueObjects
{
    public sealed class OrderItemId : ValueObject
    {
        public Guid Value { get; }

        private OrderItemId(Guid value)
        {
            Value = value;
        }

        public static OrderItemId CreateUnique() => new(Guid.NewGuid());

        public static OrderItemId Create(Guid value)
            => new OrderItemId(value);

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

#pragma warning disable CS8618
        private OrderItemId()
        {
        }
#pragma warning restore CS8618
    }
}
