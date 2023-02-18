using GarmentShop.Application.Common.Interfaces.Persistance.AuthRepositories;
using GarmentShop.Domain.AuthenticationAggregate;
using GarmentShop.Domain.AuthenticationAggregate.ValueObjects;
using GarmentShop.Infrastructure.Persistance.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace GarmentShop.Infrastructure.Persistance.Repositories.AuthAgg
{
    public class AuthenticationRepository : 
        GenericRepository<Authentication, AuthenticationId>,
        IAuthenticationRepository
    {

        public AuthenticationRepository(GarmentShopDbContext dbContext) :
            base(dbContext)
        {
        }

        public async Task<Authentication?> GetByEmail(string email)
        {
            return await dbContext.Set<Authentication>()
                .FirstOrDefaultAsync(a => a.Email == email);
        }
    }
}
