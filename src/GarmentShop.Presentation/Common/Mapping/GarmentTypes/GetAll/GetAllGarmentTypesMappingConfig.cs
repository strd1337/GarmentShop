using GarmentShop.Application.GarmentTypes.Common;
using GarmentShop.Application.GarmentTypes.Queries;
using GarmentShop.Contracts.GarmentTypes.Dtos;
using GarmentShop.Contracts.GarmentTypes.GetAll;
using Mapster;

namespace GarmentShop.Presentation.Common.Mapping.GarmentTypes.GetAll
{
    public class GetAllGarmentTypesMappingConfig
        : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<GetAllGarmentTypesRequest, GetAllGarmentTypesQuery>();

            config.NewConfig<GetAllGarmentTypesResult, GetAllGarmentTypesResponse>()
                .Map(dest => dest.Types, src => src.Types
                    .Select(type =>
                        new GarmentTypeDto(
                            type.Id.Value,
                            type.Name,
                            type.Description,
                            type.GarmentCategoryId.Value
                        )).ToList());
        }
    }
}
