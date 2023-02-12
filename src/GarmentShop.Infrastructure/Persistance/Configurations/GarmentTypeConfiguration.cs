using GarmentShop.Domain.GarmentCategoryAggregate.ValueObjects;
using GarmentShop.Domain.GarmentTypeAggregate;
using GarmentShop.Domain.GarmentTypeAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarmentShop.Infrastructure.Persistance.Configurations
{
    public class GarmentTypeConfiguration
        : IEntityTypeConfiguration<GarmentType>
    {
        public void Configure(EntityTypeBuilder<GarmentType> builder)
        {
            builder.HasKey(gt => gt.Id);

            builder.Property(gt => gt.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => GarmentTypeId.Create(value));

            builder.Property(gt => gt.Name)
                .HasMaxLength(50);

            builder.Property(gt => gt.Description)
                .HasMaxLength(200);

            builder.Property(gt => gt.GarmentCategoryId)
                .HasConversion(
                    id => id.Value,
                    value => GarmentCategoryId.Create(value));
        }
    }
}
