using GarmentShop.Application.Brands.Common;
using GarmentShop.Application.Common.CQRS;

namespace GarmentShop.Application.Brands.Queries
{
    public record GetAllBrandsQuery()
        : IQuery<GetAllBrandsResult>;
}
