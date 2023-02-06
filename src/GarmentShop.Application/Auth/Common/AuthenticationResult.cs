using GarmentShop.Domain.Entities;

namespace GarmentShop.Application.Auth.Common
{
    public record AuthenticationResult(
        User User,
        string Token);
}
