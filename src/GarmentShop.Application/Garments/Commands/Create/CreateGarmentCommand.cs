using GarmentShop.Application.Common.CQRS;
using GarmentShop.Application.Garments.Common;

namespace GarmentShop.Application.Garments.Commands.Create
{
    public record CreateGarmentCommand(
        Guid BrandId,
        Guid GarmentTypeId,
        string Name,
        string Description,
        decimal Price,
        int Size,
        int Color,
        int Material,
        int AvailableQuantity) : ICommand<CreateGarmentResult>;
}
