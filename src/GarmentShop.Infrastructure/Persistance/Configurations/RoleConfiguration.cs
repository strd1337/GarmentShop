using GarmentShop.Domain.UserAggregate.Entities;
using GarmentShop.Domain.UserAggregate.Enums;
using GarmentShop.Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarmentShop.Infrastructure.Persistance.Configurations
{
    public class RoleConfiguration
        : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            SeedRoleIds();

            ConfigureRolesTable(builder);
            ConfigureRolePermissionsTable(builder);
            SeedRoleTableWithData(builder);
        }

        private static void ConfigureRolesTable(EntityTypeBuilder<Role> builder)
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

        private static void ConfigureRolePermissionsTable(EntityTypeBuilder<Role> builder)
        {
            builder.OwnsMany(r => r.Permissions, pb =>
            {
                pb.ToTable("RolePermissions");

                pb.WithOwner().HasForeignKey("RoleId");

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

                SeedRolePermissionsTableWithData(pb);
            });

            builder.Navigation(r => r.Permissions).Metadata.SetField("permissions");
            builder.Navigation(r => r.Permissions)
                .UsePropertyAccessMode(PropertyAccessMode.Field);
        }
        private static void SeedRoleTableWithData(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(new[] {
                new {
                    Id = roleIds[0],
                    Name = Enum.GetName(typeof(RoleType), RoleType.Customer)!,
                    Type = RoleType.Customer,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = roleIds[1],
                    Name = Enum.GetName(typeof(RoleType), RoleType.Manager)!,
                    Type = RoleType.Manager,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = roleIds[2],
                    Name = Enum.GetName(typeof(RoleType), RoleType.Admin)!,
                    Type = RoleType.Admin,
                    CreatedDate = DateTime.Now, 
                    ModifiedDate = DateTime.Now
                }
            });
        }
        
        private static void SeedRolePermissionsTableWithData(
            OwnedNavigationBuilder<Role, Permission> builder)
        {
            builder.HasData(new[] {
                new {
                    Id = PermissionId.CreateUnique(),
                    RoleId = roleIds[0],
                    Name = Enum.GetName(typeof(PermissionType), PermissionType.AddToCart)!,
                    Type = PermissionType.AddToCart,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = PermissionId.CreateUnique(),
                    RoleId = roleIds[0],
                    Name = Enum.GetName(typeof(PermissionType), PermissionType.PlaceOrder)!,
                    Type = PermissionType.PlaceOrder,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = PermissionId.CreateUnique(),
                    RoleId = roleIds[0],
                    Name = Enum.GetName(typeof(PermissionType), PermissionType.ViewOrderHistory)!,
                    Type = PermissionType.ViewOrderHistory,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = PermissionId.CreateUnique(),
                    RoleId = roleIds[0],
                    Name = Enum.GetName(typeof(PermissionType), PermissionType.UpdateShippingAddress)!,
                    Type = PermissionType.UpdateShippingAddress,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = PermissionId.CreateUnique(),
                    RoleId = roleIds[1],
                    Name = Enum.GetName(typeof(PermissionType), PermissionType.EditItems)!,
                    Type = PermissionType.EditItems,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = PermissionId.CreateUnique(),
                    RoleId = roleIds[1],
                    Name = Enum.GetName(typeof(PermissionType), PermissionType.DeleteItems)!,
                    Type = PermissionType.DeleteItems,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = PermissionId.CreateUnique(),
                    RoleId = roleIds[1],
                    Name = Enum.GetName(typeof(PermissionType), PermissionType.AddItems)!,
                    Type = PermissionType.AddItems,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = PermissionId.CreateUnique(),
                    RoleId = roleIds[2],
                    Name = Enum.GetName(typeof(PermissionType), PermissionType.ManageCustomers)!,
                    Type = PermissionType.ManageCustomers,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = PermissionId.CreateUnique(),
                    RoleId = roleIds[2],
                    Name = Enum.GetName(typeof(PermissionType), PermissionType.ManageUsers)!,
                    Type = PermissionType.ManageUsers,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = PermissionId.CreateUnique(),
                    RoleId = roleIds[2],
                    Name = Enum.GetName(typeof(PermissionType), PermissionType.ManageRoles)!,
                    Type = PermissionType.ManageRoles,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = PermissionId.CreateUnique(),
                    RoleId = roleIds[2],
                    Name = Enum.GetName(typeof(PermissionType), PermissionType.ManagePermissions)!,
                    Type = PermissionType.ManagePermissions,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                },
                new {
                    Id = PermissionId.CreateUnique(),
                    RoleId = roleIds[2],
                    Name = Enum.GetName(typeof(PermissionType), PermissionType.ManageOrders)!,
                    Type = PermissionType.ManageOrders,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                }
            });
        }

        private static readonly List<RoleId> roleIds = new();

        private static void SeedRoleIds()
        {
            for(int i = 0; i < 3; ++i)
            {
                roleIds.Add(RoleId.CreateUnique());
            }
        } 
    }
}