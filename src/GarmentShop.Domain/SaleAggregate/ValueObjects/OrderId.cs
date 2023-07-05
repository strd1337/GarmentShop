using GarmentShop.Domain.Common.Models;

namespace GarmentShop.Domain.SaleAggregate.ValueObjects
{
    public sealed class OrderId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        private OrderId(Guid value)
        {
            Value = value;
        }

        public static OrderId CreateUnique() => new(Guid.NewGuid());

        public static OrderId Create(Guid value)
            => new OrderId(value);

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

#pragma warning disable CS8618
        private OrderId()
        {
        }
#pragma warning restore CS8618
    }
}
