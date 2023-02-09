using GarmentShop.Domain.AuthenticationAggregate;

namespace GarmentShop.Application.Common.Interfaces.Auth
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(Authentication user);
    }
}
