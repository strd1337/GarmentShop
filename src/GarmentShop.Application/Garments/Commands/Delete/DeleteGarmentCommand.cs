using GarmentShop.Application.Common.CQRS;
using GarmentShop.Application.Garments.Common;

namespace GarmentShop.Application.Garments.Commands.Delete
{
    public record DeleteGarmentCommand(
        Guid GarmentId) : ICommand<DeleteGarmentResult>;
}