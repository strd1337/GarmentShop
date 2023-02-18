using GarmentShop.Domain.Common.Models;
using GarmentShop.Domain.SaleAggregate.ValueObjects;

namespace GarmentShop.Domain.SaleAggregate.Entities
{
    public sealed class Order : Entity<OrderId>
    {
        private readonly List<OrderItem> items = new();
        
        public Payment Payment { get; private set; }
        public Invoice Invoice { get; private set; }
        public IReadOnlyList<OrderItem> Items
            => items.AsReadOnly(); 

        private Order(
            OrderId id,
            Payment payment,
            Invoice invoice) : base(id)
        {
            Payment = payment;
            Invoice = invoice;
        }

        public static Order Create(
            Payment payment,
            Invoice invoice)
        {
            return new(
                OrderId.CreateUnique(),
                payment,
                invoice);
        }

#pragma warning disable CS8618
        private Order()
        {
        }
#pragma warning restore CS8618
    }
}
