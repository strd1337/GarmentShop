using GarmentShop.Domain.Models;
using GarmentShop.Domain.PaymentAggregate.ValueObjects;
using GarmentShop.Domain.SalesAggregate.ValueObjects;

namespace GarmentShop.Domain.PaymentAggregate
{
    public sealed class Payment : AggregateRoot<PaymentId>
    {
        public SaleId SaleId { get; private set; }
        public DateTime Date { get; private set; }
        public string Method { get; private set; }
        public decimal Amount { get; private set; }

        private Payment(
            PaymentId id,
            SaleId saleId,
            DateTime date,
            string method,
            decimal amount) : base(id)
        {
            SaleId = saleId;
            Date = date;
            Method = method;
            Amount = amount;
        }

        public static Payment Create(
            SaleId saleId,
            DateTime date,
            string method,
            decimal amount)
        {
            return new(
                PaymentId.CreateUnique(),
                saleId,
                date,
                method,
                amount);
        }
    }
}
