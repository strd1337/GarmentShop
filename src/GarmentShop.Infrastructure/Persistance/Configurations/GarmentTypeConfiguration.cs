using GarmentShop.Domain.GarmentCategoryAggregate.ValueObjects;
using GarmentShop.Domain.GarmentTypeAggregate;
using GarmentShop.Domain.GarmentTypeAggregate.Enums;
using GarmentShop.Domain.GarmentTypeAggregate.ValueObjects;
using GarmentShop.Infrastructure.Persistance.IdentityManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarmentShop.Infrastructure.Persistance.Configurations
{
    public class GarmentTypeConfiguration
        : IEntityTypeConfiguration<GarmentType>
    {
        private readonly IdentityGenerator identityGenerator;

        public GarmentTypeConfiguration(
            IdentityGenerator identityGenerator)
        {
            this.identityGenerator = identityGenerator;
        }

        public void Configure(EntityTypeBuilder<GarmentType> builder)
        {
            ConfigureGarmentTypeTable(builder);
            SeedGarmentTypeTableWithData(builder);
        }

        private static void ConfigureGarmentTypeTable(
            EntityTypeBuilder<GarmentType> builder)
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

        private void SeedGarmentTypeTableWithData(
            EntityTypeBuilder<GarmentType> builder)
        {
            var garmentCategoryIds = identityGenerator.GarmentCategoryIds;

            builder.HasData(new[] {
                new {
                    Id = GarmentTypeId.CreateUnique(),
                    Name = GarmentTypes.Shirts.ToString(),
                    Description = "General category for upper body garments with sleeves, often buttoned or collared.",
                    GarmentCategoryId = garmentCategoryIds[0], 
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = GarmentTypeId.CreateUnique(),
                    Name =  GarmentTypes.Jeans.ToString(),
                    Description = "Denim trousers, typically made of heavy cotton, with sturdy seams and pockets.",
                    GarmentCategoryId = garmentCategoryIds[0],
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = GarmentTypeId.CreateUnique(),
                    Name =  GarmentTypes.Outerwear.ToString(),
                    Description = "Garments designed for wear outside other clothes, such as coats and jackets.",
                    GarmentCategoryId = garmentCategoryIds[0],
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = GarmentTypeId.CreateUnique(),
                    Name =  GarmentTypes.Sweaters.ToString(),
                    Description = "Knitted or crocheted garments worn on the upper body for warmth.",
                    GarmentCategoryId = garmentCategoryIds[0],
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = GarmentTypeId.CreateUnique(),
                    Name =  GarmentTypes.TShirts.ToString(),
                    Description = "Short-sleeved, typically cotton, casual shirt with a round neckline.",
                    GarmentCategoryId = garmentCategoryIds[0],
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = GarmentTypeId.CreateUnique(),
                    Name =  GarmentTypes.Pants.ToString(),
                    Description = "General category for lower body garments covering each leg separately.",
                    GarmentCategoryId = garmentCategoryIds[0],
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = GarmentTypeId.CreateUnique(),
                    Name =  GarmentTypes.Sportswear.ToString(),
                    Description = "Clothing suitable for sports or casual activities.",
                    GarmentCategoryId = garmentCategoryIds[0],
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = GarmentTypeId.CreateUnique(),
                    Name =  GarmentTypes.Jackets.ToString(),
                    Description = "Short coat with sleeves, often lightweight and designed for specific purposes.",
                    GarmentCategoryId = garmentCategoryIds[0],
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = GarmentTypeId.CreateUnique(),
                    Name =  GarmentTypes.Shorts.ToString(),
                    Description = "Garments that cover the body from the waist to the knees, typically worn in warm weather.",
                    GarmentCategoryId = garmentCategoryIds[0],
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = GarmentTypeId.CreateUnique(),
                    Name =  GarmentTypes.Pajamas.ToString(),
                    Description = "Sleepwear, typically consisting of loose-fitting trousers and a top.",
                    GarmentCategoryId = garmentCategoryIds[0],
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = GarmentTypeId.CreateUnique(),
                    Name =  GarmentTypes.Sneakers.ToString(),
                    Description = "Casual athletic shoes with a flexible sole, suitable for sports or everyday wear.",
                    GarmentCategoryId = garmentCategoryIds[0],
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = GarmentTypeId.CreateUnique(),
                    Name =  GarmentTypes.Boots.ToString(),
                    Description = "Footwear that covers the foot and ankle, often made of leather or rubber.",
                    GarmentCategoryId = garmentCategoryIds[0],
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = GarmentTypeId.CreateUnique(),
                    Name =  GarmentTypes.Slippers.ToString(),
                    Description = "Comfortable, lightweight footwear for indoor use.",
                    GarmentCategoryId = garmentCategoryIds[0],
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = GarmentTypeId.CreateUnique(),
                    Name =  GarmentTypes.Moccasins.ToString(),
                    Description = "Soft leather shoes, often with a sole made of one piece.",
                    GarmentCategoryId = garmentCategoryIds[0],
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = GarmentTypeId.CreateUnique(),
                    Name =  GarmentTypes.TShirts.ToString(),
                    Description = "Short-sleeved, typically cotton, casual shirt with a round neckline.",
                    GarmentCategoryId = garmentCategoryIds[1],
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = GarmentTypeId.CreateUnique(),
                    Name =  GarmentTypes.Jeans.ToString(),
                    Description = "Denim trousers, typically made of heavy cotton, with sturdy seams and pockets.",
                    GarmentCategoryId = garmentCategoryIds[1],
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = GarmentTypeId.CreateUnique(),
                    Name =  GarmentTypes.Sweaters.ToString(),
                    Description = "Knitted or crocheted garments worn on the upper body for warmth.",
                    GarmentCategoryId = garmentCategoryIds[1],
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = GarmentTypeId.CreateUnique(),
                    Name =  GarmentTypes.Pants.ToString(),
                    Description = "General category for lower body garments covering each leg separately.",
                    GarmentCategoryId = garmentCategoryIds[1],
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = GarmentTypeId.CreateUnique(),
                    Name =  GarmentTypes.Dresses.ToString(),
                    Description = "One-piece garments for women, typically with a fitted top and a flared skirt.",
                    GarmentCategoryId = garmentCategoryIds[1],
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = GarmentTypeId.CreateUnique(),
                    Name =  GarmentTypes.Outerwear.ToString(),
                    Description = "Garments designed for wear outside other clothes, such as coats and jackets.",
                    GarmentCategoryId = garmentCategoryIds[1],
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = GarmentTypeId.CreateUnique(),
                    Name =  GarmentTypes.Shorts.ToString(),
                    Description = "Garments that cover the body from the waist to the knees, typically worn in warm weather.",
                    GarmentCategoryId = garmentCategoryIds[1],
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = GarmentTypeId.CreateUnique(),
                    Name =  GarmentTypes.Tops.ToString(),
                    Description = "General category for upper body garments, including blouses, shirts, and sweaters.",
                    GarmentCategoryId = garmentCategoryIds[1],
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = GarmentTypeId.CreateUnique(),
                    Name =  GarmentTypes.Jackets.ToString(),
                    Description = "Short coat with sleeves, often lightweight and designed for specific purposes.",
                    GarmentCategoryId = garmentCategoryIds[1],
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = GarmentTypeId.CreateUnique(),
                    Name =  GarmentTypes.Sportswear.ToString(),
                    Description = "Clothing suitable for sports or casual activities.",
                    GarmentCategoryId = garmentCategoryIds[1],
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = GarmentTypeId.CreateUnique(),
                    Name =  GarmentTypes.Skirts.ToString(),
                    Description = "Garments worn around the waist, covering the lower body and often with a separate top.",
                    GarmentCategoryId = garmentCategoryIds[1],
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = GarmentTypeId.CreateUnique(),
                    Name =  GarmentTypes.Pajamas.ToString(),
                    Description = "Sleepwear, typically consisting of loose-fitting trousers and a top.",
                    GarmentCategoryId = garmentCategoryIds[1],
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = GarmentTypeId.CreateUnique(),
                    Name =  GarmentTypes.Sneakers.ToString(),
                    Description = "Casual athletic shoes with a flexible sole, suitable for sports or everyday wear.",
                    GarmentCategoryId = garmentCategoryIds[1],
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = GarmentTypeId.CreateUnique(),
                    Name =  GarmentTypes.Boots.ToString(),
                    Description = "Footwear that covers the foot and ankle, often made of leather or rubber.",
                    GarmentCategoryId = garmentCategoryIds[1],
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = GarmentTypeId.CreateUnique(),
                    Name =  GarmentTypes.Slippers.ToString(),
                    Description = "Comfortable, lightweight footwear for indoor use.",
                    GarmentCategoryId = garmentCategoryIds[1],
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = GarmentTypeId.CreateUnique(),
                    Name =  GarmentTypes.Sandals.ToString(),
                    Description = "Open-toed footwear with straps or thongs, suitable for warm weather.",
                    GarmentCategoryId = garmentCategoryIds[1],
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = GarmentTypeId.CreateUnique(),
                    Name =  GarmentTypes.Dresses.ToString(),
                    Description = "One-piece garments for women, typically with a fitted top and a flared skirt.",
                    GarmentCategoryId = garmentCategoryIds[2],
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = GarmentTypeId.CreateUnique(),
                    Name =  GarmentTypes.Pants.ToString(),
                    Description = "General category for lower body garments covering each leg separately.",
                    GarmentCategoryId = garmentCategoryIds[2],
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = GarmentTypeId.CreateUnique(),
                    Name =  GarmentTypes.Outerwear.ToString(),
                    Description = "Garments designed for wear outside other clothes, such as coats and jackets.",
                    GarmentCategoryId = garmentCategoryIds[2],
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = GarmentTypeId.CreateUnique(),
                    Name =  GarmentTypes.TShirts.ToString(),
                    Description = "Short-sleeved, typically cotton, casual shirt with a round neckline.",
                    GarmentCategoryId = garmentCategoryIds[2],
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = GarmentTypeId.CreateUnique(),
                    Name =  GarmentTypes.Sweaters.ToString(),
                    Description = "Knitted or crocheted garments worn on the upper body for warmth.",
                    GarmentCategoryId = garmentCategoryIds[2],
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = GarmentTypeId.CreateUnique(),
                    Name =  GarmentTypes.Jeans.ToString(),
                    Description = "Denim trousers, typically made of heavy cotton, with sturdy seams and pockets.",
                    GarmentCategoryId = garmentCategoryIds[2],
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = GarmentTypeId.CreateUnique(),
                    Name =  GarmentTypes.Skirts.ToString(),
                    Description = "Garments worn around the waist, covering the lower body and often with a separate top.",
                    GarmentCategoryId = garmentCategoryIds[2],
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = GarmentTypeId.CreateUnique(),
                    Name =  GarmentTypes.Shorts.ToString(),
                    Description = "Garments that cover the body from the waist to the knees, typically worn in warm weather.",
                    GarmentCategoryId = garmentCategoryIds[2],
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = GarmentTypeId.CreateUnique(),
                    Name =  GarmentTypes.Pajamas.ToString(),
                    Description = "Sleepwear, typically consisting of loose-fitting trousers and a top.",
                    GarmentCategoryId = garmentCategoryIds[2],
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = GarmentTypeId.CreateUnique(),
                    Name =  GarmentTypes.Sneakers.ToString(),
                    Description = "Casual athletic shoes with a flexible sole, suitable for sports or everyday wear.",
                    GarmentCategoryId = garmentCategoryIds[2],
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = GarmentTypeId.CreateUnique(),
                    Name =  GarmentTypes.Boots.ToString(),
                    Description = "Footwear that covers the foot and ankle, often made of leather or rubber.",
                    GarmentCategoryId = garmentCategoryIds[2],
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = GarmentTypeId.CreateUnique(),
                    Name =  GarmentTypes.Slippers.ToString(),
                    Description = "Comfortable, lightweight footwear for indoor use.",
                    GarmentCategoryId = garmentCategoryIds[2],
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = GarmentTypeId.CreateUnique(),
                    Name =  GarmentTypes.Sandals.ToString(),
                    Description = "Open-toed footwear with straps or thongs, suitable for warm weather.",
                    GarmentCategoryId = garmentCategoryIds[2],
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = GarmentTypeId.CreateUnique(),
                    Name =  GarmentTypes.Outerwear.ToString(),
                    Description = "Garments designed for wear outside other clothes, such as coats and jackets.",
                    GarmentCategoryId = garmentCategoryIds[3],
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = GarmentTypeId.CreateUnique(),
                    Name =  GarmentTypes.Sweaters.ToString(),
                    Description = "Knitted or crocheted garments worn on the upper body for warmth.",
                    GarmentCategoryId = garmentCategoryIds[3],
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = GarmentTypeId.CreateUnique(),
                    Name =  GarmentTypes.TShirts.ToString(),
                    Description = "Short-sleeved, typically cotton, casual shirt with a round neckline.",
                    GarmentCategoryId = garmentCategoryIds[3],
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = GarmentTypeId.CreateUnique(),
                    Name =  GarmentTypes.Shorts.ToString(),
                    Description = "Garments that cover the body from the waist to the knees, typically worn in warm weather.",
                    GarmentCategoryId = garmentCategoryIds[3],
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = GarmentTypeId.CreateUnique(),
                    Name =  GarmentTypes.Jeans.ToString(),
                    Description = "Denim trousers, typically made of heavy cotton, with sturdy seams and pockets.",
                    GarmentCategoryId = garmentCategoryIds[3],
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = GarmentTypeId.CreateUnique(),
                    Name =  GarmentTypes.Pants.ToString(),
                    Description = "General category for lower body garments covering each leg separately.",
                    GarmentCategoryId = garmentCategoryIds[3],
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = GarmentTypeId.CreateUnique(),
                    Name =  GarmentTypes.SwimTrunks.ToString(),
                    Description = "Shorts designed for swimming or other water activities.",
                    GarmentCategoryId = garmentCategoryIds[3],
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = GarmentTypeId.CreateUnique(),
                    Name =  GarmentTypes.Shirts.ToString(),
                    Description = "General category for upper body garments with sleeves, often buttoned or collared.",
                    GarmentCategoryId = garmentCategoryIds[3],
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = GarmentTypeId.CreateUnique(),
                    Name =  GarmentTypes.Sportswear.ToString(),
                    Description = "Clothing suitable for sports or casual activities.",
                    GarmentCategoryId = garmentCategoryIds[3],
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = GarmentTypeId.CreateUnique(),
                    Name =  GarmentTypes.Pajamas.ToString(),
                    Description = "Sleepwear, typically consisting of loose-fitting trousers and a top.",
                    GarmentCategoryId = garmentCategoryIds[3],
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = GarmentTypeId.CreateUnique(),
                    Name =  GarmentTypes.Sneakers.ToString(),
                    Description = "Casual athletic shoes with a flexible sole, suitable for sports or everyday wear.",
                    GarmentCategoryId = garmentCategoryIds[3],
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = GarmentTypeId.CreateUnique(),
                    Name =  GarmentTypes.Boots.ToString(),
                    Description = "Footwear that covers the foot and ankle, often made of leather or rubber.",
                    GarmentCategoryId = garmentCategoryIds[3],
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = GarmentTypeId.CreateUnique(),
                    Name =  GarmentTypes.Slippers.ToString(),
                    Description = "Comfortable, lightweight footwear for indoor use.",
                    GarmentCategoryId = garmentCategoryIds[3],
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = GarmentTypeId.CreateUnique(),
                    Name =  GarmentTypes.Sandals.ToString(),
                    Description = "Open-toed footwear with straps or thongs, suitable for warm weather.",
                    GarmentCategoryId = garmentCategoryIds[3],
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                }
            });
        }
    }
}
