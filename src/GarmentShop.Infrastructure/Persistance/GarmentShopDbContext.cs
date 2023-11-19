using GarmentShop.Domain.AuthenticationAggregate;
using GarmentShop.Domain.BrandAggregate;
using GarmentShop.Domain.Common.Outbox;
using GarmentShop.Domain.GarmentAggregate;
using GarmentShop.Domain.GarmentCategoryAggregate;
using GarmentShop.Domain.GarmentTypeAggregate;
using GarmentShop.Domain.SaleAggregate;
using GarmentShop.Domain.UserAggregate;
using GarmentShop.Domain.UserAggregate.Entities;
using GarmentShop.Infrastructure.Persistance.Configurations;
using GarmentShop.Infrastructure.Persistance.IdentityManagement;
using Microsoft.EntityFrameworkCore;

namespace GarmentShop.Infrastructure.Persistance
{
    public class GarmentShopDbContext : DbContext
    {
        public GarmentShopDbContext(
            DbContextOptions<GarmentShopDbContext> options) 
                : base(options)
        {         
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfigurationsFromAssembly(
                    typeof(GarmentShopDbContext).Assembly);

            base.OnModelCreating(modelBuilder);

            IdentityGenerator identityGenerator = IdentityGenerator.Create();
            modelBuilder.ApplyConfiguration(
                new GarmentTypeConfiguration(identityGenerator));
            modelBuilder.ApplyConfiguration(
                new GarmentCategoryConfiguration(identityGenerator));
        }

        public DbSet<Authentication> RegisteredUsers { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<Brand> Brands { get; set; } = null!;
        public DbSet<Garment> Garments { get; set; } = null!;
        public DbSet<GarmentCategory> GarmentCategories { get; set; } = null!;
        public DbSet<GarmentType> GarmentTypes { get; set; } = null!;
        public DbSet<Sale> Sales { get; set; } = null!;
        public DbSet<OutboxMessage> OutboxMessages { get; set; } = null!;
        public DbSet<OutboxMessageConsumer> OutboxMessageConsumers { get; set; } = null!;
    }
}
