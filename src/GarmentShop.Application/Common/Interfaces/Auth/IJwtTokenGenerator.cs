using GarmentShop.Domain.Entities;

namespace GarmentShop.Application.Common.Interfaces.Auth
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
