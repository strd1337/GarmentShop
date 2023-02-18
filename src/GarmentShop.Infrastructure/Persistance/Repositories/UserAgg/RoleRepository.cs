using GarmentShop.Application.Common.Interfaces.Persistance.UserRepositories;
using GarmentShop.Domain.UserAggregate.Entities;
using GarmentShop.Domain.UserAggregate.ValueObjects;
using GarmentShop.Infrastructure.Persistance.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace GarmentShop.Infrastructure.Persistance.Repositories.UserAgg
{
    public class RoleRepository :
        GenericRepository<Role, RoleId>,
        IRoleRepository
    {
        public RoleRepository(GarmentShopDbContext dbContext) 
            : base(dbContext)
        {
        }

        public Task AddPermissionAsync(Role role, Permission permission)
        {
            role.AddPermission(permission);
            return Task.CompletedTask;
        }

        public async Task<Role?> FindByNameAsync(
            string name, 
            CancellationToken cancellationToken = default)
        {
            return await dbContext.Roles
                .FirstOrDefaultAsync(r => r.Name == name, cancellationToken);
        }
    }
}
