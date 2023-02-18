using ErrorOr;
using MediatR;

namespace GarmentShop.Application.Common.CQRS
{
    public interface ICommand : IRequest<Error>
    {
    }

    public interface ICommand<TResponse> : IRequest<ErrorOr<TResponse>>
    {
    }
}
