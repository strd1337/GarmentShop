using GarmentShop.Application.Common.CQRS;
using GarmentShop.Application.Users.Common;

namespace GarmentShop.Application.Users.Queries
{
    public record UserProfileQuery(string UserName) 
        : IQuery<UserProfileResult>;
}
