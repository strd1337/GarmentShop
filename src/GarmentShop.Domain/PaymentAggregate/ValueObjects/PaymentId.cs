using GarmentShop.Domain.Models;

namespace GarmentShop.Domain.PaymentAggregate.ValueObjects
{
    public sealed class PaymentId : ValueObject
    {
        public Guid Value { get; }

        private PaymentId(Guid value)
        {
            Value = value;
        }
         
        public static PaymentId CreateUnique() => new(Guid.NewGuid());

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
