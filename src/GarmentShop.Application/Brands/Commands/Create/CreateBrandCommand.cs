using GarmentShop.Application.Brands.Common;
using GarmentShop.Application.Common.CQRS;

namespace GarmentShop.Application.Brands.Commands.Create
{
    public record CreateBrandCommand(
        string Name,
        string Description) : ICommand<CreateBrandResult>;
}
