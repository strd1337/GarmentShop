using GarmentShop.Domain.Common.Models;
using GarmentShop.Domain.GarmentCategoryAggregate.ValueObjects;

namespace GarmentShop.Domain.GarmentCategoryAggregate
{
    public sealed class GarmentCategory : AggregateRoot<GarmentCategoryId, Guid>
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        private GarmentCategory(
            GarmentCategoryId id,
            string name,
            string description) : base(id)
        {
            Name = name;
            Description = description;
        }

        public static GarmentCategory Create(
            string name,
            string description)
        {
            return new(
                GarmentCategoryId.CreateUnique(),
                name,
                description);
        }

#pragma warning disable CS8618
        private GarmentCategory()
        {
        }
#pragma warning restore CS8618
    }
}
