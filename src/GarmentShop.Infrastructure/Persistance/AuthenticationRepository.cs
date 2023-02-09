using GarmentShop.Application.Common.Interfaces.Persistance;
using GarmentShop.Domain.AuthenticationAggregate;

namespace GarmentShop.Infrastructure.Persistance
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private static readonly List<Authentication> Users = new();
        
        public void CreateUser(Authentication user)
        {
            Users.Add(user);
        }

        public Authentication? FindUserByEmail(string email)
        {
            return Users.SingleOrDefault(u => u.Email == email);
        }
    }
}
