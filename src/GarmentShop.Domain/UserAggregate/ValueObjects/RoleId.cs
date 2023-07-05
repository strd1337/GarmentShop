using GarmentShop.Domain.Common.Models;

namespace GarmentShop.Domain.UserAggregate.ValueObjects
{
    public sealed class RoleId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        private RoleId(Guid value)
        {
            Value = value;
        }

        public static RoleId CreateUnique() => new(Guid.NewGuid());

        public static RoleId Create(Guid value)
            => new RoleId(value);

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

#pragma warning disable CS8618
        private RoleId()
        {
        }
#pragma warning restore CS8618
    }
}
