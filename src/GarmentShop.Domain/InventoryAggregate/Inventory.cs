using GarmentShop.Domain.GarmentAggregate.ValueObjects;
using GarmentShop.Domain.InventoryAggregate.ValueObjects;
using GarmentShop.Domain.Models;

namespace GarmentShop.Domain.InventoryAggregate
{
    public sealed class Inventory : AggregateRoot<InventoryId>
    {
        public GarmentId GarmentId { get; private set; }
        public int Quantity { get; private set; }
        public string Description { get; private set; }

        private Inventory(
            InventoryId id,
            GarmentId garmentId,
            int quantity,
            string description) : base(id)
        {
            GarmentId = garmentId;
            Quantity = quantity;
            Description = description;
        }

        public static Inventory Create(
            GarmentId garmentId,
            int quantity,
            string description)
        {
            return new(
                InventoryId.CreateUnique(),
                garmentId,
                quantity,
                description);
        }
    }
}
