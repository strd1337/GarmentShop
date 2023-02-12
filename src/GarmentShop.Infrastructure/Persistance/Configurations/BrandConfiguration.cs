using GarmentShop.Domain.BrandAggregate;
using GarmentShop.Domain.BrandAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarmentShop.Infrastructure.Persistance.Configurations
{
    public class BrandConfiguration
        : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => BrandId.Create(value));

            builder.Property(b => b.Name)
                .HasMaxLength(50);

            builder.Property(b => b.Description)
                .HasMaxLength(200);
        }
    }
}