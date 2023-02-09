using GarmentShop.Domain.UserAggregate.ValueObjects;
using GarmentShop.Domain.GarmentAggregate.ValueObjects;
using GarmentShop.Domain.Models;
using GarmentShop.Domain.PaymentAggregate.ValueObjects;
using GarmentShop.Domain.SalesAggregate.ValueObjects;

namespace GarmentShop.Domain.SalesAggregate
{
    public sealed class Sale : AggregateRoot<SaleId>
    {
        private readonly List<PaymentId> paymentIds = new();

        public UserId UserId { get; private set; }
        public GarmentId GarmentId { get; private set; }
        public DateTime Date { get; private set; }
        public int Quantity { get; private set; }
        public decimal TotalPrice { get; private set; }
        public IReadOnlyList<PaymentId> PaymentIds => paymentIds.AsReadOnly();

        private Sale(
            SaleId id,
            UserId userId,
            GarmentId garmentId, 
            DateTime date,
            int quantity,
            decimal totalPrice) : base(id)
        {
            UserId = userId;
            GarmentId = garmentId;
            Date = date;
            Quantity = quantity;
            TotalPrice = totalPrice;
        }

        public static Sale Create(
            UserId userId,
            GarmentId garmentId,
            DateTime date,
            int quantity,
            decimal totalPrice)
        {
            return new(
                SaleId.CreateUnique(),
                userId,
                garmentId,
                date,
                quantity,
                totalPrice);
        }

        public void AddPayment(PaymentId paymentId)
        {
            paymentIds.Add(paymentId);
        }

        public void RemovePayment(PaymentId paymentId)
        {
            paymentIds.Remove(paymentId);
        }
    }
}
