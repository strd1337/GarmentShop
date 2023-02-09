using GarmentShop.Domain.GarmentAggregate.ValueObjects;
using GarmentShop.Domain.Models;
using GarmentShop.Domain.StockAggregate.Enums;
using GarmentShop.Domain.StockAggregate.ValueObjects;

namespace GarmentShop.Domain.StockAggregate
{
    public sealed class Stock : AggregateRoot<StockId>
    {
        public GarmentId GarmentId { get; }
        public int Quantity { get; private set; }
        public StockStatus Status { get; private set; } 
        public int ReorderLevel { get; private set; }
        public DateTime ReorderDate { get; private set; } 

        private Stock(
            StockId id,
            GarmentId garmentId,
            StockStatus status, 
            int reorderLevel, 
            DateTime reorderDate) : base(id)
        {
            GarmentId = garmentId;
            Status = status;
            ReorderLevel = reorderLevel;
            ReorderDate = reorderDate;
        }

        public static Stock Create(
            StockId id,
            GarmentId garmentId,
            StockStatus status,
            int reorderLevel,
            DateTime reorderDate)
        {
            return new(
                StockId.CreateUnique(),
                garmentId,
                status,
                reorderLevel,
                reorderDate);
        }

        public void Update(
            int? quantity = null,
            StockStatus? status = null,
            int? reorderLevel = null,
            DateTime? reorderDate = null) 
        {
            if (quantity.HasValue) 
            {
                Quantity = quantity.Value;
            }

            if (status.HasValue)
            {
                Status = status.Value;
            }

            if (reorderLevel.HasValue)
            {
                ReorderLevel = reorderLevel.Value;
            }

            if (reorderDate.HasValue)
            {
                ReorderDate = reorderDate.Value;
            }
        }
    }
}
