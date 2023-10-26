using GarmentShop.Domain.Common.Models;

namespace GarmentShop.Domain.GarmentCategoryAggregate.ValueObjects
{
    public sealed class GarmentCategoryId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        private GarmentCategoryId(Guid value)
        {
            Value = value;
        }

        public static GarmentCategoryId CreateUnique() => new(Guid.NewGuid());

        public static GarmentCategoryId Create(Guid value)
            => new GarmentCategoryId(value);

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

#pragma warning disable CS8618
        private GarmentCategoryId()
        {
        }
#pragma warning restore CS8618
    }
}
