using GarmentShop.Domain.Common.Models;

namespace GarmentShop.Domain.BrandAggregate.ValueObjects
{
    public sealed class BrandId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        private BrandId(Guid value)
        {
            Value = value;
        }

        public static BrandId CreateUnique() => new(Guid.NewGuid());

        public static BrandId Create(Guid value)
            => new BrandId(value);

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

#pragma warning disable CS8618
        private BrandId()
        {
        }
#pragma warning restore CS8618
    }
}
