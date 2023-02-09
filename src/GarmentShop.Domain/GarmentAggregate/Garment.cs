using GarmentShop.Domain.BrandAggregate.ValueObjects;
using GarmentShop.Domain.GarmentAggregate.Enums;
using GarmentShop.Domain.GarmentAggregate.ValueObjects;
using GarmentShop.Domain.Models;
using GarmentShop.Domain.SalesAggregate.ValueObjects;

namespace GarmentShop.Domain.GarmentAggregate
{
    public sealed class Garment : AggregateRoot<GarmentId>
    {
        private readonly List<SaleId> saleIds = new();

        public string Name { get; private set; } 
        public string Description { get; private set; } 
        public decimal Price { get; private set; }
        public Size Size { get; private set; }
        public Color Color { get; private set; }
        public Material Material { get; private set; }
        public BrandId BrandId { get; private set; }
        public IReadOnlyList<SaleId> SaleIds => saleIds.AsReadOnly();

        private Garment(
            GarmentId id,
            string name,
            string description,
            decimal price,
            Size size,
            Color color,
            Material material,
            BrandId brandId) : base(id)
        {
            Name = name;
            Description = description;
            Price = price;
            Size = size;
            Color = color;
            Material = material;
            BrandId = brandId;
        }

        public static Garment Create(
            string name,
            string description,
            decimal price,
            Size size,
            Color color,
            Material material,
            BrandId brandId)
        {
            return new(
                GarmentId.CreateUnique(),
                name,
                description,
                price,
                size,
                color,
                material,
                brandId);
        }

        public void AddSale(SaleId saleId)
        {
            saleIds.Add(saleId);
        }

        public void RemoveSale(SaleId saleId)
        {
            saleIds.Remove(saleId);
        }

        public void Update(
            string? name = null,
            string? description = null,
            decimal? price = null,
            Size? size = null,
            Color? color = null,
            Material? material = null,
            BrandId? brandId = null) 
        {
            if (name is not null)
            {
                Name = name;
            }

            if (description is not null)
            {
                Description = description;
            }

            if (price.HasValue)
            {
                Price = price.Value;
            }

            if (size is not null)
            {
                Size = size.Value;
            }

            if (color is not null)
            {
                Color = color.Value;
            }

            if (material is not null)
            {
                Material = material.Value;
            }

            if (brandId is not null)
            {
                BrandId = brandId;
            }
        }
    }
}
