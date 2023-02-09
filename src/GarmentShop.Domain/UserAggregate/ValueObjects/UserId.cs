using GarmentShop.Domain.Models;

namespace GarmentShop.Domain.UserAggregate.ValueObjects
{
    public sealed class UserId : ValueObject
    {
        public Guid Value { get; }

        private UserId(Guid value)
        {
            Value = value;
        }
         
        public static UserId CreateUnique() => new(Guid.NewGuid());

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
