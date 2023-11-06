using GarmentShop.Domain.UserAggregate.ValueObjects;

namespace GarmentShop.Application.Users.Common
{
    public record UserProfileUpdateResult(
        Guid UserId,
        UserDetailInformation Information);
}
