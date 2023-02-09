using GarmentShop.Domain.BrandAggregate.ValueObjects;
using GarmentShop.Domain.GarmentAggregate.ValueObjects;
using GarmentShop.Domain.Models;

namespace GarmentShop.Domain.BrandAggregate
{
    public sealed class Brand : AggregateRoot<BrandId>
    {
        private readonly List<GarmentId> garmentIds = new();

        public string Name { get; private set; }
        public string Description { get; private set; }
        public IReadOnlyList<GarmentId> Garments => garmentIds.AsReadOnly();

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
         
        public void AddGarment(GarmentId garmentId)
        { 
            garmentIds.Add(garmentId);
        }

        public void Update(
            string? name = null, 
            string? description = null)
        {
            if (name is not null)
            {
                Name = name;
            }

            if (description is not null)
            {
                Description = description;
            }
        }
         
        public void RemoveGarment(GarmentId garmentId)
        {
            garmentIds.Remove(garmentId);
        }
    }
}
