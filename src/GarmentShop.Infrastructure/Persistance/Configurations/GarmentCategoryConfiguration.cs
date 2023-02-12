using GarmentShop.Domain.GarmentCategoryAggregate;
using GarmentShop.Domain.GarmentCategoryAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarmentShop.Infrastructure.Persistance.Configurations
{
    public class GarmentCategoryConfiguration
        : IEntityTypeConfiguration<GarmentCategory>
    {
        public void Configure(EntityTypeBuilder<GarmentCategory> builder)
        {
            builder.HasKey(gc => gc.Id);

            builder.Property(gc => gc.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => GarmentCategoryId.Create(value));

            builder.Property(gc => gc.Name)
                .HasMaxLength(50);

            builder.Property(gc => gc.Description)
                .HasMaxLength(200);
        }
    }
}
