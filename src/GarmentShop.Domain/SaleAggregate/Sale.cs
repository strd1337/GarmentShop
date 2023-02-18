using GarmentShop.Domain.Common.Models;
using GarmentShop.Domain.SaleAggregate.Entities;
using GarmentShop.Domain.SaleAggregate.ValueObjects;
using GarmentShop.Domain.UserAggregate;
using GarmentShop.Domain.UserAggregate.ValueObjects;

namespace GarmentShop.Domain.SaleAggregate
{
    public sealed class Sale : AggregateRoot<SaleId>
    {
        private readonly List<Order> orders = new();

        public UserId UserId { get; private set; }
        public IReadOnlyList<Order> Orders => orders.AsReadOnly();

        private Sale(
            SaleId id,
            UserId userId) : base(id)
        {
            UserId = userId;
        }
        
        public static Sale Create(
            UserId userId) => new(SaleId.CreateUnique(), userId);

#pragma warning disable CS8618
        private Sale()
        {
        }
#pragma warning restore CS8618
    }
}
