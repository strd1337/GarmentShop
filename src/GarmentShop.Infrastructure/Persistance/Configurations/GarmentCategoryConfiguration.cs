using GarmentShop.Domain.GarmentCategoryAggregate;
using GarmentShop.Domain.GarmentCategoryAggregate.ValueObjects;
using GarmentShop.Infrastructure.Persistance.IdentityManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarmentShop.Infrastructure.Persistance.Configurations
{
    public class GarmentCategoryConfiguration
        : IEntityTypeConfiguration<GarmentCategory>
    {
        private readonly IdentityGenerator identityGenerator;

        public GarmentCategoryConfiguration(
            IdentityGenerator identityGenerator)
        {
            this.identityGenerator = identityGenerator;
        }

        public void Configure(EntityTypeBuilder<GarmentCategory> builder)
        {
            ConfigureGarmentCategoryTable(builder);
            SeedGarmentCategoryTableWithData(builder);
        }

        private static void ConfigureGarmentCategoryTable(
            EntityTypeBuilder<GarmentCategory> builder)
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

        private void SeedGarmentCategoryTableWithData(
            EntityTypeBuilder<GarmentCategory> builder)
        {
            var garmentCategoryIds = identityGenerator.GarmentCategoryIds;

            builder.HasData(new[] {
                new {
                    Id = garmentCategoryIds[0],
                    Name = "For Men",
                    Description = "Includes products specifically designed for mens.",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = garmentCategoryIds[1],
                    Name = "For Women",
                    Description = "Includes products specifically designed for womens.",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = garmentCategoryIds[2],
                    Name = "For Girls",
                    Description = "Includes products specifically designed for young females.",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = garmentCategoryIds[3],
                    Name = "For Boys",
                    Description = "Includes products specifically designed for young males.",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                }
            });
        }
    }
}
