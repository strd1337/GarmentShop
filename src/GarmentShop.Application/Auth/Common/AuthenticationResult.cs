using GarmentShop.Domain.AuthenticationAggregate;

namespace GarmentShop.Application.Auth.Common
{
    public record AuthenticationResult(
        Authentication User,
        string Token);
}
