using GarmentShop.Application.GarmentCategories.Common;
using GarmentShop.Application.GarmentCategories.Queries;
using GarmentShop.Contracts.GarmentCategories.Dtos;
using GarmentShop.Contracts.GarmentCategories.GetAll;
using Mapster;

namespace GarmentShop.Presentation.Common.Mapping.GarmentCategories.GetAll
{
    public class GetAllGarmentCategoriesMappingConfig
        : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<GetAllGarmentCategoriesRequest, GetAllGarmentCategoriesQuery>();

            config.NewConfig<GetAllGarmentCategoriesResult, GetAllGarmentCategoriesResponse>()
                .Map(dest => dest.Categories, src => src.Categories
                    .Select(category =>
                        new GarmentCategoryDto(
                            category.Id.Value,
                            category.Name,
                            category.Description
                        )).ToList());
        }
    }
}
