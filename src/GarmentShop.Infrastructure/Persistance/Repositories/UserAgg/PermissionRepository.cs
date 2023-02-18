using GarmentShop.Application.Common.Interfaces.Persistance.UserRepositories;
using GarmentShop.Domain.UserAggregate.Entities;
using GarmentShop.Domain.UserAggregate.ValueObjects;
using GarmentShop.Infrastructure.Persistance.Repositories.Common;

namespace GarmentShop.Infrastructure.Persistance.Repositories.UserAgg
{
    public class PermissionRepository :
        GenericRepository<Permission, PermissionId>,
        IPermissionRepository
    {
        public PermissionRepository(GarmentShopDbContext dbContext) 
            : base(dbContext)
        {
        }
    }
}
