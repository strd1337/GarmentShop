using GarmentShop.Domain.UserAggregate.Enums;
using Microsoft.AspNetCore.Authorization;

namespace GarmentShop.Infrastructure.Auth.Roles
{
    public sealed class HasRoleAttribute : AuthorizeAttribute
    {
        public HasRoleAttribute(RoleType role)
        : base(policy: role.ToString())
        {
        }
    }
}