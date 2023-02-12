using GarmentShop.Domain.GarmentAggregate.ValueObjects;
using GarmentShop.Domain.SaleAggregate;
using GarmentShop.Domain.SaleAggregate.Entities;
using GarmentShop.Domain.SaleAggregate.ValueObjects;
using GarmentShop.Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarmentShop.Infrastructure.Persistance.Configurations
{
    public class SaleConfiguration
        : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            ConfigureSalesTable(builder);
            ConfigureSaleOrdersTable(builder);
        }

        private static void ConfigureSalesTable(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("Sales");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => SaleId.Create(value));

            builder.Property(s => s.UserId)
                .HasConversion(
                    id => id.Value,
                    value => UserId.Create(value));
        }

        private static void ConfigureSaleOrdersTable(EntityTypeBuilder<Sale> builder)
        {
            builder.OwnsMany(s => s.Orders, ob =>
            {
                ob.ToTable("SaleOrders");

                ob.WithOwner().HasForeignKey("SaleId");

                ob.HasKey("Id", "SaleId");

                ob.Property(o => o.Id)
                    .HasColumnName("SaleOrderId")
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        value => OrderId.Create(value));

                ob.OwnsOne(o => o.Payment, pb =>
                {
                    pb.Property(p => p.Method)
                        .HasColumnName("Method")
                        .HasConversion<string>()
                        .HasMaxLength(50);

                    pb.Property(p => p.Amount)
                        .HasPrecision(10, 2);
                });

                ob.OwnsOne(o => o.Invoice, ib =>
                {
                    ib.Property(p => p.TotalCost)
                        .HasColumnName("TotalCost")
                        .HasPrecision(10, 2);

                    ib.Property(p => p.Tax)
                        .HasColumnName("Tax")
                        .HasPrecision(10, 2);

                    ib.Property(p => p.ShippingAndHandling)
                        .HasColumnName("ShippingAndHandling")
                        .HasPrecision(10, 2);

                    ib.Property(p => p.OtherCharges)
                    .HasColumnName("OtherCharges")
                        .HasPrecision(10, 2);
                });

                ob.OwnsMany(ob => ob.Items, ib =>
                {
                    ib.ToTable("OrderItems");

                    ib.WithOwner().HasForeignKey("SaleOrderId", "SaleId");

                    ib.HasKey(nameof(OrderItem.Id), "SaleOrderId", "SaleId");

                    ib.Property(ib => ib.Id)
                        .HasColumnName("OrderItemId")
                        .ValueGeneratedNever()
                        .HasConversion(
                            id => id.Value,
                            value => OrderItemId.Create(value));

                    ib.Property(ib => ib.UnitPrice)
                        .HasColumnName("UnitPrice")
                        .HasPrecision(10, 2);

                    ib.Property(ib => ib.Quantity)
                        .HasColumnName("Quantity");

                    ib.Property(ib => ib.GarmentId)
                        .HasColumnName("GarmentId")
                        .HasConversion(
                            id => id.Value,
                            value => GarmentId.Create(value));
                });

                ob.Navigation(o => o.Items).Metadata.SetField("items");
                ob.Navigation(o => o.Items)
                    .UsePropertyAccessMode(PropertyAccessMode.Field);
            });

            builder.Metadata.FindNavigation(nameof(Sale.Orders))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}