using GarmentShop.Application.Common.Interfaces.Persistance.AuthRepositories;
using GarmentShop.Application.Common.Interfaces.Persistance.CommonRepositories;
using GarmentShop.Application.Common.Interfaces.Persistance.UserRepositories;
using GarmentShop.Infrastructure.Persistance.Repositories.AuthAgg;
using GarmentShop.Infrastructure.Persistance.Repositories.UserAgg;

namespace GarmentShop.Infrastructure.Persistance.Repositories.Common
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly GarmentShopDbContext dbContext;
        private bool isDisposed;
        private IAuthenticationRepository? authenticationRepository;
        private IUserRepository? userRepository;
        private IRoleRepository? roleRepository;
        private IPermissionRepository? permissionRepository;

        public IAuthenticationRepository AuthenticationRepository =>
           authenticationRepository ??= new AuthenticationRepository(dbContext);
         
        public IUserRepository UserRepository =>
            userRepository ??= new UserRepository(dbContext);

        public IRoleRepository RoleRepository =>
            roleRepository ??= new RoleRepository(dbContext);

        public IPermissionRepository PermissionRepository =>
            permissionRepository ??= new PermissionRepository(dbContext);

        public UnitOfWork(GarmentShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return dbContext.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            if (!isDisposed)
            {
                dbContext.Dispose();
                isDisposed = true;
            }
        }
    }
}
