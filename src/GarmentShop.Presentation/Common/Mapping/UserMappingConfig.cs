using GarmentShop.Application.Users.Common;
using GarmentShop.Contracts.User;
using Mapster;

namespace GarmentShop.Presentation.Common.Mapping
{
    public class UserMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<UserProfileResult, UserProfileResponse>()
                .Map(dest => dest.UserId, src => src.AuthUser.UserId.Value)
                .Map(dest => dest.Email, src => src.AuthUser.Email)
                .Map(dest => dest.UserName, src => src.AuthUser.UserName)
                .Map(dest => dest.FirstName, src => src.User.Information.FirstName ?? "")
                .Map(dest => dest.LastName, src => src.User.Information.LastName ?? "")
                .Map(dest => dest.PhoneNumber, src => src.User.Information.PhoneNumber ?? "")
                .Map(dest => dest.Address, src => src.User.Information.Address ?? "")
                .Map(dest => dest.City, src => src.User.Information.City ?? "")
                .Map(dest => dest.ZipCode, src => src.User.Information.ZipCode ?? "")
                .Map(dest => dest.Country, src => src.User.Information.Country ?? "");
        }
    }
}