using GarmentShop.Application.Common.Interfaces.Persistance;
using GarmentShop.Domain.Entities;

namespace GarmentShop.Infrastructure.Persistance
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> Users = new();
        public void Add(User user)
        {
            Users.Add(user);
        }

        public User? GetUserByEmail(string email)
        {
            return Users.SingleOrDefault(u => u.Email == email);
        }
    }
}
