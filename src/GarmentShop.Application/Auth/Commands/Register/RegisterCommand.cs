using ErrorOr;
using GarmentShop.Application.Auth.Common;
using MediatR;

namespace GarmentShop.Application.Auth.Commands.Register
{
    public record RegisterCommand(
        string UserName,
        string Email,
        string Password) : IRequest<ErrorOr<AuthenticationResult>>;
}
