using GarmentShop.Application.Common.CQRS;
using GarmentShop.Application.GarmentCategories.Common;

namespace GarmentShop.Application.GarmentCategories.Queries
{
    public record GetAllGarmentCategoriesQuery()
        : IQuery<GetAllGarmentCategoriesResult>;
}
