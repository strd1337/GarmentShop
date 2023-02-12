using GarmentShop.Domain.BrandAggregate.ValueObjects;
using GarmentShop.Domain.GarmentAggregate;
using GarmentShop.Domain.GarmentAggregate.ValueObjects;
using GarmentShop.Domain.GarmentTypeAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarmentShop.Infrastructure.Persistance.Configurations
{
    public class GarmentConfiguration
        : IEntityTypeConfiguration<Garment>
    {
        public void Configure(EntityTypeBuilder<Garment> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => GarmentId.Create(value));

            builder.Property(g => g.Name)
                .HasMaxLength(50);

            builder.Property(g => g.Description)
                .HasMaxLength(200);

            builder.Property(g => g.Price)
                .HasPrecision(10, 2);

            builder.Property(g => g.Size)
                .HasConversion<string>()
                .HasMaxLength(50);

            builder.Property(g => g.Color)
                .HasConversion<string>()
                .HasMaxLength(50);

            builder.Property(g => g.Material)
                .HasConversion<string>()
                .HasMaxLength(50); 

            builder.Property(g => g.BrandId)
                .HasConversion(
                    id => id.Value,
                    value => BrandId.Create(value));

            builder.Property(g => g.GarmentTypeId)
                .HasConversion(
                    id => id.Value,
                    value => GarmentTypeId.Create(value));
        }
    }
}
