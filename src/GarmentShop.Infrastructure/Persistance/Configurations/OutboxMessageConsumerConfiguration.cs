using GarmentShop.Domain.Common.Outbox;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarmentShop.Infrastructure.Persistance.Configurations
{
    public class OutboxMessageConsumerConfiguration
        : IEntityTypeConfiguration<OutboxMessageConsumer>
    {
        public void Configure(EntityTypeBuilder<OutboxMessageConsumer> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Name)
                .HasMaxLength(100);
        }
    }
}
