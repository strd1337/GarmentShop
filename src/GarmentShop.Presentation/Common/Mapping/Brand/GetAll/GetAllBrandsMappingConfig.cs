using GarmentShop.Application.Brands.Common;
using GarmentShop.Application.Brands.Queries;
using GarmentShop.Contracts.Brands.Dtos;
using GarmentShop.Contracts.Brands.GetAll;
using Mapster;

namespace GarmentShop.Presentation.Common.Mapping.Brand.GetAll
{
    public class GetAllBrandsMappingConfig
        : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<GetAllBrandsRequest, GetAllBrandsQuery>();

            config.NewConfig<GetAllBrandsResult, GetAllBrandsResponse>()
                .Map(dest => dest.Brands, src => src.Brands
                    .Select(brands =>
                        new BrandDto(
                            brands.Id.Value,
                            brands.Name,
                            brands.Description
                        )).ToList());
        }
    }
}
