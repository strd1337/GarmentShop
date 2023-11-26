using GarmentShop.Application.Garments.Common;
using GarmentShop.Contracts.Garments.Dtos;
using GarmentShop.Contracts.Garments.GetAllByBrand;
using Mapster;

namespace GarmentShop.Presentation.Common.Mapping.Garments.GetAllByBrand
{
    public class GetAllGarmentsByBrandMappingConfig
        : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<GetAllGarmentsByBrandResult, GetAllGarmentsByBrandResponse>()
                .Map(dest => dest.Garments, src => src.Garments
                    .Select(garments =>
                        new GarmentDto(
                            garments.Id.Value,
                            garments.BrandId.Value,
                            garments.GarmentTypeId.Value,
                            garments.Name,
                            garments.Description,
                            garments.Price,
                            garments.Size.ToString(),
                            garments.Color.ToString(),
                            garments.Material.ToString(),
                            garments.AvailableQuantity
                        )).ToList());
        }
    }
}
