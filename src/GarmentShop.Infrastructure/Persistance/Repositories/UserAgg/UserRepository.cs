using GarmentShop.Application.Common.Interfaces.Persistance.UserRepositories;
using GarmentShop.Domain.UserAggregate;
using GarmentShop.Domain.UserAggregate.Entities;
using GarmentShop.Domain.UserAggregate.ValueObjects;
using GarmentShop.Infrastructure.Persistance.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace GarmentShop.Infrastructure.Persistance.Repositories.UserAgg
{
    public class UserRepository : 
        GenericRepository<User, UserId>,
        IUserRepository
    {
        public UserRepository(GarmentShopDbContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<User?> FindByIdAsync(
            UserId id, 
            CancellationToken cancellationToken = default)
        {
            return await dbContext.Users
                .Include(u => u.Roles)
                    .ThenInclude(u => u.Role)
                        .ThenInclude(r => r.Permissions)
                .AsSplitQuery()
                .FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
        }

        public Task AddRoleAsync(User user, Role role)
        {
            user.AddRole(role);
            return Task.CompletedTask;
        }
    }
}
