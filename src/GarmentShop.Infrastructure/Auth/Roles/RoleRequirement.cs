using Microsoft.AspNetCore.Authorization;

namespace GarmentShop.Infrastructure.Auth.Roles
{
    public  class RoleRequirement : IAuthorizationRequirement
    {
        public string Role { get; }

        public RoleRequirement(string role)
        {
            Role = role;
        }
    }
}
