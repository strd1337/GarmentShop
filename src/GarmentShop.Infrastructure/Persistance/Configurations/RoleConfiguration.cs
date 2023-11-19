using GarmentShop.Domain.UserAggregate.Entities;
using GarmentShop.Domain.UserAggregate.Enums;
using GarmentShop.Domain.UserAggregate.ValueObjects;
using GarmentShop.Infrastructure.Persistance.IdentityManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarmentShop.Infrastructure.Persistance.Configurations
{
    public class RoleConfiguration
        : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            var roleIds = IdentityGenerator.Create().RoleIds;

            ConfigureRolesTable(builder);
            ConfigureRolePermissionsTable(builder, roleIds);
            SeedRoleTableWithData(builder, roleIds);
        }

        private static void ConfigureRolesTable(
            EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => RoleId.Create(value));

            builder.Property(r => r.Name)
                    .HasColumnName("Name")
                    .HasMaxLength(50);

            builder.Property(r => r.Type)
                .HasColumnName("Type")
                .HasConversion<int>()
                .HasMaxLength(50);
        }

        private static void ConfigureRolePermissionsTable(
            EntityTypeBuilder<Role> builder,
            IReadOnlyList<RoleId> roleIds)
        {
            builder.OwnsMany(r => r.Permissions, pb =>
            {
                pb.ToTable("RolePermissions");

                pb.WithOwner().HasForeignKey("RoleId").HasPrincipalKey("Id");

                pb.HasKey(nameof(Permission.Id), "RoleId");

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

                SeedRolePermissionsTableWithData(pb, roleIds);
            });

            builder.Navigation(r => r.Permissions).Metadata.SetField("permissions");
            builder.Navigation(r => r.Permissions)
                .UsePropertyAccessMode(PropertyAccessMode.Field);
        }

        private static void SeedRoleTableWithData(
            EntityTypeBuilder<Role> builder,
            IReadOnlyList<RoleId> roleIds)
        {
            builder.HasData(new[] {
                new {
                    Id = roleIds[0],
                    Name = RoleType.Customer.ToString(),
                    Type = RoleType.Customer,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = roleIds[1],
                    Name = RoleType.Manager.ToString(),
                    Type = RoleType.Manager,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = roleIds[2],
                    Name = RoleType.Admin.ToString(),
                    Type = RoleType.Admin,
                    CreatedDate = DateTime.Now, 
                    ModifiedDate = DateTime.Now
                }
            });
        }
        
        private static void SeedRolePermissionsTableWithData(
            OwnedNavigationBuilder<Role, Permission> builder,
            IReadOnlyList<RoleId> roleIds)
        {
            builder.HasData(new[] {
                new {
                    Id = PermissionId.CreateUnique(),
                    RoleId = roleIds[0],
                    Name = PermissionType.AddToCart.ToString(),
                    Type = PermissionType.AddToCart,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = PermissionId.CreateUnique(),
                    RoleId = roleIds[0],
                    Name = PermissionType.PlaceOrder.ToString(),
                    Type = PermissionType.PlaceOrder,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = PermissionId.CreateUnique(),
                    RoleId = roleIds[0],
                    Name = PermissionType.ViewOrderHistory.ToString(),
                    Type = PermissionType.ViewOrderHistory,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = PermissionId.CreateUnique(),
                    RoleId = roleIds[0],
                    Name = PermissionType.UpdateShippingAddress.ToString(),
                    Type = PermissionType.UpdateShippingAddress,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = PermissionId.CreateUnique(),
                    RoleId = roleIds[1],
                    Name = PermissionType.EditItems.ToString(),
                    Type = PermissionType.EditItems,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = PermissionId.CreateUnique(),
                    RoleId = roleIds[1],
                    Name = PermissionType.DeleteItems.ToString(),
                    Type = PermissionType.DeleteItems,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = PermissionId.CreateUnique(),
                    RoleId = roleIds[1],
                    Name = PermissionType.AddItems.ToString(),
                    Type = PermissionType.AddItems,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = PermissionId.CreateUnique(),
                    RoleId = roleIds[2],
                    Name = PermissionType.ManageCustomers.ToString(),
                    Type = PermissionType.ManageCustomers,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = PermissionId.CreateUnique(),
                    RoleId = roleIds[2],
                    Name = PermissionType.ManageUsers.ToString(),
                    Type = PermissionType.ManageUsers,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = PermissionId.CreateUnique(),
                    RoleId = roleIds[2],
                    Name = PermissionType.ManageRoles.ToString(),
                    Type = PermissionType.ManageRoles,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = PermissionId.CreateUnique(),
                    RoleId = roleIds[2],
                    Name = PermissionType.ManagePermissions.ToString(),
                    Type = PermissionType.ManagePermissions,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = PermissionId.CreateUnique(),
                    RoleId = roleIds[2],
                    Name = PermissionType.ManageOrders.ToString(),
                    Type = PermissionType.ManageOrders,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                }
            });
        }
    }
}