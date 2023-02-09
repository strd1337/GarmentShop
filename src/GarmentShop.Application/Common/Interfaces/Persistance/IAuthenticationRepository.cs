using GarmentShop.Domain.AuthenticationAggregate;

namespace GarmentShop.Application.Common.Interfaces.Persistance
{
    public interface IAuthenticationRepository
    {
        void CreateUser(Authentication user);
        Authentication? FindUserByEmail(string email);  
    }  
}  
  