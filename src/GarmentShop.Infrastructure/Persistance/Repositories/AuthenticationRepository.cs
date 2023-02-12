using GarmentShop.Application.Common.Interfaces.Persistance;
using GarmentShop.Domain.AuthenticationAggregate;

namespace GarmentShop.Infrastructure.Persistance.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly GarmentShopDbContext dbContext;

        public AuthenticationRepository(GarmentShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CreateUser(Authentication user)
        {
            dbContext.RegisteredUsers.Add(user);
            dbContext.SaveChanges();
        }

        public Authentication? FindUserByEmail(string email)
        {
            return dbContext.RegisteredUsers.SingleOrDefault(u => u.Email == email);
        }
    }
}
