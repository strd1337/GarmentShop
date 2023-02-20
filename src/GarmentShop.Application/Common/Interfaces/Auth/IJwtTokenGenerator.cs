using GarmentShop.Domain.AuthenticationAggregate;
using GarmentShop.Domain.UserAggregate;

namespace GarmentShop.Application.Common.Interfaces.Auth
{
    public interface IJwtTokenGenerator
    {
       string GenerateToken(Authentication authUser, User user);
    }
}
