using GarmentShop.Domain.UserAggregate;
using GarmentShop.Domain.UserAggregate.Entities;
using GarmentShop.Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarmentShop.Infrastructure.Persistance.Configurations
{
    public class UserConfiguration
        : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            ConfigureUsersTable(builder);
            ConfigureUserSaleIdsTable(builder);
            ConfigureUserRolesTable(builder);
        }
         
        private static void ConfigureUsersTable(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => UserId.Create(value));

            builder.OwnsOne(u => u.Information, ib =>
            {
                ib.Property(i => i.FirstName)
                    .HasColumnName("FirstName")
                    .HasMaxLength(50);

                ib.Property(i => i.LastName)
                    .HasColumnName("LastName")
                    .HasMaxLength(50);

                ib.Property(i => i.PhoneNumber)
                    .HasColumnName("PhoneNumber")
                    .HasMaxLength(30);

                ib.Property(i => i.Address)
                    .HasColumnName("Address")
                    .HasMaxLength(200);

                ib.Property(i => i.Country)
                    .HasColumnName("Country")
                    .HasMaxLength(50);

                ib.Property(i => i.City)
                    .HasColumnName("City")
                    .HasMaxLength(50);

                ib.Property(i => i.ZipCode)
                    .HasColumnName("ZipCode")
                    .HasMaxLength(15);
            });
        }
        
        private static void ConfigureUserSaleIdsTable(EntityTypeBuilder<User> builder)
        {
            builder.OwnsMany(u => u.SaleIds, sib =>
            {
                sib.ToTable("UserSaleIds");

                sib.WithOwner().HasForeignKey("UserId");

                sib.HasKey("Id");

                sib.Property(si => si.Value)
                    .HasColumnName("SaleId")
                    .ValueGeneratedNever();
            });
        }

        private static void ConfigureUserRolesTable(EntityTypeBuilder<User> builder)
        {

            builder.OwnsMany(u => u.Roles, rb =>
            {
                rb.ToTable("UserRoles");

                rb.WithOwner().HasForeignKey("UserId");
      
                rb.HasKey("Id", "RoleId");

                rb.HasOne(ur => ur.Role)
                    .WithMany()
                    .HasForeignKey("RoleId")
                    .OnDelete(DeleteBehavior.Cascade);

                rb.Property(r => r.Id)
                    .HasColumnName("UserRoleId")
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        value => UserRoleId.Create(value));

                rb.HasOne(ur => ur.Role)
                   .WithMany()
                   .HasForeignKey("RoleId")
                   .OnDelete(DeleteBehavior.Cascade);

                rb.Navigation(ur => ur.Role).UsePropertyAccessMode(PropertyAccessMode.Property);
            });

            builder.Metadata.FindNavigation(nameof(User.Roles))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}