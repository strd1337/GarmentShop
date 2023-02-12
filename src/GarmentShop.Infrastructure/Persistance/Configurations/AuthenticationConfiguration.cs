using GarmentShop.Domain.AuthenticationAggregate;
using GarmentShop.Domain.AuthenticationAggregate.ValueObjects;
using GarmentShop.Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarmentShop.Infrastructure.Persistance.Configurations
{
    public class AuthenticationConfiguration
        : IEntityTypeConfiguration<Authentication>
    {
        public void Configure(EntityTypeBuilder<Authentication> builder)
        {
            builder.HasKey(auth => auth.Id);

            builder.Property(auth => auth.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => AuthenticationId.Create(value));

            builder.Property(auth => auth.UserName)
                .HasMaxLength(50);

            builder.Property(auth => auth.Email)
                .HasMaxLength(100);

            builder.Property(auth => auth.PasswordHash)
                .HasMaxLength(500);

            builder.Property(auth => auth.Salt)
                .HasMaxLength(500);

            builder.Property(auth => auth.UserId)
                .HasConversion(
                    id => id.Value,
                    value => UserId.Create(value));
        }
    }
}
