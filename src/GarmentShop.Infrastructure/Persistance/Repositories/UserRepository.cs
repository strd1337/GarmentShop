using GarmentShop.Application.Common.Interfaces.Persistance;
using GarmentShop.Domain.UserAggregate;
using Microsoft.EntityFrameworkCore;

namespace GarmentShop.Infrastructure.Persistance.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly GarmentShopDbContext dbContext;

        public UserRepository(GarmentShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(User user)
        {
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
        }

        public async Task<User?> GetUserByIdAsync(Guid id)
        {
            return await dbContext.Users
                .FirstOrDefaultAsync(u => u.Id.Value == id);
        }
    }
}
