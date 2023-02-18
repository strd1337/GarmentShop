using GarmentShop.Application.Common.Interfaces.Persistance.CommonRepositories;
using GarmentShop.Domain.UserAggregate;
using GarmentShop.Domain.UserAggregate.Entities;
using GarmentShop.Domain.UserAggregate.ValueObjects;

namespace GarmentShop.Application.Common.Interfaces.Persistance.UserRepositories
{
    public interface IUserRepository
        : IGenericRepository<User, UserId>
    {
        Task<User?> FindByIdAsync(UserId id, 
            CancellationToken cancellationToken = default);

        Task AddRoleAsync(User user, Role role);
    }
}
