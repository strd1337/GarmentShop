using GarmentShop.Application.Auth.Common;
using GarmentShop.Application.Common.CQRS;

namespace GarmentShop.Application.Auth.Queries.Login
{
    public record LoginQuery(
        string Email,
        string Password) : IQuery<AuthenticationResult>;
}
