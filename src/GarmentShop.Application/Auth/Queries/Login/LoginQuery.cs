using ErrorOr;
using GarmentShop.Application.Auth.Common;
using MediatR;

namespace GarmentShop.Application.Auth.Queries.Login
{
    public record LoginQuery(
        string Email,
        string Password) : IRequest<ErrorOr<AuthenticationResult>>;
}
