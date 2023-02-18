using GarmentShop.Application.Auth.Common;
using GarmentShop.Application.Common.CQRS;

namespace GarmentShop.Application.Auth.Commands.Register
{
    public record RegisterCommand(
        string UserName,
        string Email,
        string Password) : ICommand<AuthenticationResult>;
}
