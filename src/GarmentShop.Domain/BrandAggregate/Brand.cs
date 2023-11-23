using GarmentShop.Domain.BrandAggregate.ValueObjects;
using GarmentShop.Domain.Common.Models;
using GarmentShop.Domain.Events.Brand;
using GarmentShop.Domain.UserAggregate.ValueObjects;
using Microsoft.VisualBasic;

namespace GarmentShop.Domain.BrandAggregate
{
    public sealed class Brand : AggregateRoot<BrandId, Guid>
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
            var createdBrand = new Brand(
                BrandId.CreateUnique(),
                name,
                description);

            createdBrand.RaiseDomainEvent(
                new BrandCreatedEvent(
                    Guid.NewGuid(),
                    createdBrand.Id.Value,
                    createdBrand.Name,
                    createdBrand.Description));

            return createdBrand;
        }

        public void Update(
            string name,
            string description)
        {
            Name = name;
            Description = description;
        }


#pragma warning disable CS8618
        private Brand()
        {
        }
#pragma warning restore CS8618
    }
}
