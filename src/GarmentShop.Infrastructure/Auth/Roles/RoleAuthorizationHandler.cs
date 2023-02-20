using Microsoft.AspNetCore.Authorization;

namespace GarmentShop.Infrastructure.Auth.Roles
{
    public sealed class RoleAuthorizationHandler
        : AuthorizationHandler<RoleRequirement>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context, 
            RoleRequirement requirement)
        {
            var roles = context
                .User
                .Claims
                .Where(c => c.Type == CustomClaims.Roles)
                .Select(c => c.Value)
                .ToHashSet();

            if (roles.Contains(requirement.Role))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
