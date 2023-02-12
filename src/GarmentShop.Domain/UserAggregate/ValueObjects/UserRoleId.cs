using GarmentShop.Domain.Models;

namespace GarmentShop.Domain.UserAggregate.ValueObjects
{
    public sealed class UserRoleId : ValueObject
    {
        public Guid Value { get; }

        private UserRoleId(Guid value)
        {
            Value = value;
        }

        public static UserRoleId CreateUnique() => new(Guid.NewGuid());

        public static UserRoleId Create(Guid value)
            => new UserRoleId(value);

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

#pragma warning disable CS8618
        private UserRoleId()
        {
        }
#pragma warning restore CS8618
    }
}
