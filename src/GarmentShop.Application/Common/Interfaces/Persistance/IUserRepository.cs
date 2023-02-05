using GarmentShop.Domain.Entities;

namespace GarmentShop.Application.Common.Interfaces.Persistance
{
    public interface IUserRepository
    {
        User? GetUserByEmail(string email);  
        void Add(User user);
    }
}
