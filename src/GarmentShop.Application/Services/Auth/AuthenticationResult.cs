using GarmentShop.Domain.Entities;

namespace GarmentShop.Application.Services.Auth
{
    public record AuthenticationResult(
        User User,
        string Token);
}
