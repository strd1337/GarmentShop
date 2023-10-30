using GarmentShop.Application.Auth.Common;
using GarmentShop.Contracts.Authentication;
using Mapster;

namespace GarmentShop.Presentation.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest.UserId, src => src.User.UserId.Value)
                .Map(dest => dest, src => src.User);
        }
    }
}