using GarmentShop.Domain.BrandAggregate.ValueObjects;
using GarmentShop.Domain.Models;

namespace GarmentShop.Domain.BrandAggregate
{
    public sealed class Brand : AggregateRoot<BrandId>
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        private Brand(
            BrandId id,
            string name,
            string description) : base(id)
        {
            Name = name;
            Description = description;
        }

        public static Brand Create(
            string name,
            string description)
        {
            return new(
                BrandId.CreateUnique(),
                name,
                description);
        }


#pragma warning disable CS8618
        private Brand()
        {
        }
#pragma warning restore CS8618
    }
}
