using ErrorOr;
using GarmentShop.Domain.UserAggregate;
using MediatR;

namespace GarmentShop.Application.Users.Queries.GetUserInfo
{
    public record GetUserInfoQuery(
        Guid Id) : IRequest<ErrorOr<User>>;
}