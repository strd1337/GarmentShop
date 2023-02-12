using GarmentShop.Domain.BrandAggregate.ValueObjects;
using GarmentShop.Domain.GarmentAggregate.Enums;
using GarmentShop.Domain.GarmentAggregate.ValueObjects;
using GarmentShop.Domain.GarmentTypeAggregate.ValueObjects;
using GarmentShop.Domain.Models;

namespace GarmentShop.Domain.GarmentAggregate
{
    public sealed class Garment : AggregateRoot<GarmentId>
    {
        public string Name { get; private set; }    
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public Size Size { get; private set; }
        public Color Color { get; private set; }
        public Material Material { get; private set; }
        public int AvailableQuantity { get; private set; }
        public BrandId BrandId { get; private set; }
        public GarmentTypeId GarmentTypeId { get; private set; }

        private Garment(
            GarmentId id,
            string name,
            string description,
            decimal price,
            Size size,
            Color color,
            Material material,
            int availableQuantity,
            BrandId brandId,
            GarmentTypeId garmentTypeId) : base(id)
        {
            Name = name;
            Description = description;
            Price = price;
            Size = size;
            Color = color;
            Material = material;
            AvailableQuantity = availableQuantity;
            BrandId = brandId;
            GarmentTypeId = garmentTypeId;
        }

        public static Garment Create(
            string name,
            string description,
            decimal price,
            Size size,
            Color color,
            Material material,
            int availableQuantity,
            BrandId brandId,
            GarmentTypeId garmentTypeId)
        {
            return new(
                GarmentId.CreateUnique(),
                name,
                description,
                price,
                size,
                color,
                material,
                availableQuantity,
                brandId,
                garmentTypeId);
        }

#pragma warning disable CS8618
        private Garment()
        {
        }
#pragma warning restore CS8618
    }
}
