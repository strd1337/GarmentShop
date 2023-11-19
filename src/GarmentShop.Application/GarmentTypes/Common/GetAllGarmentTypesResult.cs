using GarmentShop.Domain.GarmentTypeAggregate;

namespace GarmentShop.Application.GarmentTypes.Common
{
    public record GetAllGarmentTypesResult(
        ICollection<GarmentType> Types);
}
