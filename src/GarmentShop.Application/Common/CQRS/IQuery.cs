using ErrorOr;
using MediatR;

namespace GarmentShop.Application.Common.CQRS
{
    public interface IQuery<TResponse> : IRequest<ErrorOr<TResponse>>
    {
    }
}
