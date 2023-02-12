using GarmentShop.Application.Users.Queries.GetUserInfo;
using GarmentShop.Contracts.Users;
using GarmentShop.Domain.UserAggregate;
using Mapster;

namespace GarmentShop.Presentation.Common.Mapping
{
    public class UserMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<User, GetUserInfoResponse>()
                .Map(dest => dest.Id, src => src.Id.Value);

            config.NewConfig<Guid, GetUserInfoQuery>()
                .Map(dest => dest.Id, src => src);
        }
    }
}
