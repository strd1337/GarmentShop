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

        public static AuthenticationId Create(Guid value) 
            => new AuthenticationId(value);

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

#pragma warning disable CS8618
        private AuthenticationId()
        {
        }
#pragma warning restore CS8618
    }
}
