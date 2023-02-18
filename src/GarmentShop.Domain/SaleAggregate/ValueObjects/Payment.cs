using GarmentShop.Domain.Common.Models;
using GarmentShop.Domain.SaleAggregate.Enums;

namespace GarmentShop.Domain.SaleAggregate.ValueObjects
{
    public sealed class Payment : ValueObject
    {
        public PaymentMethod Method { get; private set; }
        public DateTime Date { get; private set; }
        public decimal Amount { get; private set; }

        private Payment(
            PaymentMethod method,
            DateTime date,
            decimal amount)
        {
            Method = method;
            Date = date;
            Amount = amount;
        }

        public static Payment CreateNew(
            PaymentMethod method,
            DateTime date,
            decimal amount)
        {
            return new(
                method,
                date,
                amount);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Method;
            yield return Date;
            yield return Amount;
        }

#pragma warning disable CS8618
        private Payment()
        {
        }
#pragma warning restore CS8618
    }
}
