using GarmentShop.Application.Common.Interfaces.Persistance.CommonRepositories;
using GarmentShop.Domain.UserAggregate.Entities;
using GarmentShop.Domain.UserAggregate.ValueObjects;

namespace GarmentShop.Application.Common.Interfaces.Persistance.UserRepositories
{
    public interface IRoleRepository 
        : IGenericRepository<Role, RoleId>
    {
        Task AddPermissionAsync(Role role, Permission permission);
    }
}
