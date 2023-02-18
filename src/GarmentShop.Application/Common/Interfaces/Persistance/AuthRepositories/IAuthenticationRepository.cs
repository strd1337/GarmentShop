using GarmentShop.Application.Common.Interfaces.Persistance.CommonRepositories;
using GarmentShop.Domain.AuthenticationAggregate;
using GarmentShop.Domain.AuthenticationAggregate.ValueObjects;

namespace GarmentShop.Application.Common.Interfaces.Persistance.AuthRepositories
{
    public interface IAuthenticationRepository :
        IGenericRepository<Authentication, AuthenticationId>
        
    {
        Task<Authentication?> GetByEmail(string email);
    }
}
