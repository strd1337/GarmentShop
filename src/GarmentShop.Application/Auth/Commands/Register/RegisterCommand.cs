using ErrorOr;
using GarmentShop.Application.Auth.Common;
using MediatR;

namespace GarmentShop.Application.Auth.Commands.Register
{
    public record RegisterCommand(
        string FirstName,
        string LastName,
        string Email,
        string Password) : IRequest<ErrorOr<AuthenticationResult>>;
}
