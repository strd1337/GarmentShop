using GarmentShop.Domain.AuthenticationAggregate;
using GarmentShop.Domain.UserAggregate;

namespace GarmentShop.Application.Users.Common
{
    public record UserProfileResult(
        Authentication AuthUser,
        User User);
}
