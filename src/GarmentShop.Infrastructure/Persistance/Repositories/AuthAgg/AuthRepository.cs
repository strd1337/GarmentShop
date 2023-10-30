using GarmentShop.Application.Common.Interfaces.Persistance.AuthRepositories;
using GarmentShop.Domain.AuthenticationAggregate;
using GarmentShop.Domain.AuthenticationAggregate.ValueObjects;
using GarmentShop.Infrastructure.Persistance.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace GarmentShop.Infrastructure.Persistance.Repositories.AuthAgg
{
    public class AuthRepository :
        GenericRepository<Authentication, AuthenticationId>,
        IAuthRepository
    {
        public AuthRepository(GarmentShopDbContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<bool> IsEmailUniqueAsync(
            string email, 
            CancellationToken cancellationToken = default)
        {
            return await dbContext.RegisteredUsers
                .AnyAsync(u => u.Email.Equals(email), cancellationToken);
        }

        public async Task<bool> IsUsernameUniqueAsync(
            string userName, 
            CancellationToken cancellationToken = default)
        {
            return await dbContext.RegisteredUsers
               .AnyAsync(u => u.UserName.Equals(userName), cancellationToken);
        }
    }
}
