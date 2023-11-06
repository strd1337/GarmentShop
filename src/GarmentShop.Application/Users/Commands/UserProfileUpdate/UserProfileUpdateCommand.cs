using GarmentShop.Application.Common.CQRS;
using GarmentShop.Application.Users.Common;

namespace GarmentShop.Application.Users.Commands.UserProfileUpdate
{
    public record UserProfileUpdateCommand(
        Guid UserId,
        string FirstName,
        string LastName,
        string PhoneNumber,
        string Address,
        string City,
        string ZipCode,
        string Country) : ICommand<UserProfileUpdateResult>;
}
