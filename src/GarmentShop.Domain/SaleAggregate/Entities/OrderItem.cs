using GarmentShop.Domain.GarmentAggregate.ValueObjects;
using GarmentShop.Domain.Models;
using GarmentShop.Domain.SaleAggregate.ValueObjects;

namespace GarmentShop.Domain.SaleAggregate.Entities
{
    public sealed class OrderItem : Entity<OrderItemId>
    { 
        public GarmentId GarmentId { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }

        private OrderItem(
            OrderItemId id,
            GarmentId garmentId,
            int quantity,
            decimal unitPrice) : base(id)
        {
            GarmentId = garmentId;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        public static OrderItem Create(
            GarmentId garmentId,
            int quantity,
            decimal unitPrice)
        {
            return new(
                OrderItemId.CreateUnique(),
                garmentId,
                quantity,
                unitPrice);
        }

#pragma warning disable CS8618
        private OrderItem()
        {
        }
#pragma warning restore CS8618
    }
}
