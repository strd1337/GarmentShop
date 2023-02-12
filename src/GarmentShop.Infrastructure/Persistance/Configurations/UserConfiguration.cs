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

                rb.HasKey("Id", "UserId");

                rb.Property(r => r.Id)
                    .HasColumnName("UserRoleId")
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        value => UserRoleId.Create(value));

                rb.Property(r => r.Name)
                    .HasColumnName("Name")
                    .HasMaxLength(50);

                rb.Property(r => r.Type)
                    .HasColumnName("Type")
                    .HasConversion<int>()
                    .HasMaxLength(50);

                rb.OwnsMany(r => r.Permissions, pb =>
                {
                    pb.ToTable("RolePermissions");

                    pb.WithOwner().HasForeignKey("UserRoleId", "UserId");

                    pb.HasKey(nameof(Permission.Id), "UserRoleId", "UserId");

                    pb.Property(r => r.Id)
                    .HasColumnName("PermissionId")
                        .ValueGeneratedNever()
                        .HasConversion(
                            id => id.Value,
                            value => PermissionId.Create(value));

                    pb.Property(r => r.Name)
                    .HasColumnName("Name")
                    .HasMaxLength(50);

                    pb.Property(r => r.Type)
                        .HasColumnName("Type")
                        .HasConversion<int>()
                        .HasMaxLength(50);
                });

                rb.Navigation(r => r.Permissions).Metadata.SetField("permissions");
                rb.Navigation(r => r.Permissions)
                    .UsePropertyAccessMode(PropertyAccessMode.Field);
            });

            builder.Metadata.FindNavigation(nameof(User.Roles))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}