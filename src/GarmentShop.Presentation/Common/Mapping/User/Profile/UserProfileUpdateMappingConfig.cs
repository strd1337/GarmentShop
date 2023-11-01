using GarmentShop.Application.Users.Common;
using GarmentShop.Contracts.User.UpdateProfile;
using Mapster;

namespace GarmentShop.Presentation.Common.Mapping.User.Profile
{
    public class UserProfileUpdateMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<UserProfileUpdateResult, UserProfileUpdateResponse>()
                .Map(dest => dest, src => src.Information);
        }
    }
}
