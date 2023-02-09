using GarmentShop.Domain.Models;

namespace GarmentShop.Domain.AuthenticationAggregate.ValueObjects
{ 
    public sealed class AuthenticationId : ValueObject
    {
        public Guid Value { get; }

        private AuthenticationId(Guid value)
        {
            Value = value;
        } 

        public static AuthenticationId CreateUnique() => new(Guid.NewGuid());

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
