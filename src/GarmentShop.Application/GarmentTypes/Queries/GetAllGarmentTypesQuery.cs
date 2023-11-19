using GarmentShop.Application.Common.CQRS;
using GarmentShop.Application.GarmentTypes.Common;

namespace GarmentShop.Application.GarmentTypes.Queries
{
    public record GetAllGarmentTypesQuery()
        : IQuery<GetAllGarmentTypesResult>;
}
