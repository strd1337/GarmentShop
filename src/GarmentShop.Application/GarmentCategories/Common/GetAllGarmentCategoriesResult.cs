using GarmentShop.Domain.GarmentCategoryAggregate;

namespace GarmentShop.Application.GarmentCategories.Common
{
    public record GetAllGarmentCategoriesResult(
        ICollection<GarmentCategory> Categories);
}
