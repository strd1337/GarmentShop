using GarmentShop.Domain.UserAggregate.Enums;
using Microsoft.AspNetCore.Authorization;

namespace GarmentShop.Infrastructure.Auth.Permissions
{
    public sealed class HasPermissionAttribute : AuthorizeAttribute
    {
        public HasPermissionAttribute(PermissionType permission)
            : base(policy: permission.ToString())
        {
        }
    }
}
