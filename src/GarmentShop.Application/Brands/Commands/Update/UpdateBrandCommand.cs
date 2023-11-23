using GarmentShop.Application.Brands.Common;
using GarmentShop.Application.Common.CQRS;

namespace GarmentShop.Application.Brands.Commands.Update
{
    public record UpdateBrandCommand(
        Guid BrandId,
        string Name,
        string Description) : ICommand<UpdateBrandResult>;
}
