using GarmentShop.Application.Common.Interfaces.Persistance.AuthRepositories;
using GarmentShop.Application.Common.Interfaces.Persistance.UserRepositories;

namespace GarmentShop.Application.Common.Interfaces.Persistance.CommonRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        IAuthenticationRepository AuthenticationRepository { get; }
        IUserRepository UserRepository { get; }
        IRoleRepository RoleRepository { get; }
        IPermissionRepository PermissionRepository { get; }
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
