using GarmentShop.Domain.Common.Models;

namespace GarmentShop.Domain.UserAggregate.ValueObjects
{
    public sealed class PermissionId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        private PermissionId(Guid value)
        {
            Value = value;
        }

        public static PermissionId CreateUnique() => new(Guid.NewGuid());

        public static PermissionId Create(Guid value)
            => new PermissionId(value);

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

#pragma warning disable CS8618
        private PermissionId() 
        {
        }
#pragma warning restore CS8618
    }
}
