using GarmentShop.Application.Common.Interfaces.Persistance.CommonRepositories;
using GarmentShop.Domain.AuthenticationAggregate;
using GarmentShop.Domain.AuthenticationAggregate.ValueObjects;

namespace GarmentShop.Application.Common.Interfaces.Persistance.AuthRepositories
{
    public interface IAuthRepository
        : IGenericRepository<Authentication, AuthenticationId>
    {
        Task<bool> IsUsernameUniqueAsync(string userName,
            CancellationToken cancellationToken = default);

        Task<bool> IsEmailUniqueAsync(string email,
            CancellationToken cancellationToken = default);
    }
} 
