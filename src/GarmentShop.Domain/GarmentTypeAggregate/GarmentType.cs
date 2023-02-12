using GarmentShop.Domain.GarmentCategoryAggregate.ValueObjects;
using GarmentShop.Domain.GarmentTypeAggregate.ValueObjects;
using GarmentShop.Domain.Models;

namespace GarmentShop.Domain.GarmentTypeAggregate
{
    public sealed class GarmentType : AggregateRoot<GarmentTypeId>
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public GarmentCategoryId GarmentCategoryId { get; private set; }

        private GarmentType(
            GarmentTypeId id,
            string name,
            string description,
            GarmentCategoryId garmentCategoryId) : base(id)
        {
            Name = name;
            Description = description;
            GarmentCategoryId = garmentCategoryId;
        }

        public static GarmentType Create(
            string name,
            string description,
            GarmentCategoryId garmentCategoryId)
        {
            return new(
                GarmentTypeId.CreateUnique(),
                name,
                description,
                garmentCategoryId);
        }

#pragma warning disable CS8618
        private GarmentType()
        {
        }
#pragma warning restore CS8618
    }
}
