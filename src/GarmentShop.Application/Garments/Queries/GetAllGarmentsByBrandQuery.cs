using GarmentShop.Application.Common.CQRS;
using GarmentShop.Application.Garments.Common;

namespace GarmentShop.Application.Garments.Queries
{
    public record GetAllGarmentsByBrandQuery(
        string BrandName) : IQuery<GetAllGarmentsByBrandResult>;
}
