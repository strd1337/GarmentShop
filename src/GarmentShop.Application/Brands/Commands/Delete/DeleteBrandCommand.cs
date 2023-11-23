using GarmentShop.Application.Brands.Common;
using GarmentShop.Application.Common.CQRS;

namespace GarmentShop.Application.Brands.Commands.Delete
{
    public record DeleteBrandCommand(
        Guid BrandId) : ICommand<DeleteBrandResult>;
}
