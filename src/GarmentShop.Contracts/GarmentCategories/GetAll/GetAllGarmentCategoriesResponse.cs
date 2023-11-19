using GarmentShop.Contracts.GarmentCategories.Dtos;

namespace GarmentShop.Contracts.GarmentCategories.GetAll
{
    public record GetAllGarmentCategoriesResponse(
        ICollection<GarmentCategoryDto> Categories);
}
