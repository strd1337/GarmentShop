using ErrorOr;
using GarmentShop.Domain.UserAggregate;

namespace GarmentShop.Application.Common.Interfaces.Persistance
{
    public interface IUserRepository
    {
        void Create(User user);
        Task<User?> GetUserByIdAsync(Guid id); 
    }
} 
