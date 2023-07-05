using GarmentShop.Domain.AuthenticationAggregate;

namespace GarmentShop.Application.Auth.Common
{
    public record AuthenticationResult(
        Guid AuthId,
        Authentication User,
        string Token);
}
