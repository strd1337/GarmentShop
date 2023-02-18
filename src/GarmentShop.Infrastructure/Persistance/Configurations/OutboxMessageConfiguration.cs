using GarmentShop.Domain.Common.Outbox;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarmentShop.Infrastructure.Persistance.Configurations
{
    public class OutboxMessageConfiguration
        : IEntityTypeConfiguration<OutboxMessage>
    {
        public void Configure(EntityTypeBuilder<OutboxMessage> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Type)
                .HasMaxLength(500);
            
            builder.Property(o => o.Content)
                .HasMaxLength(500);

            builder.Property(o => o.Error)
                .HasMaxLength(500);
        }
    }
}