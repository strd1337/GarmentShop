using ErrorOr;
using MediatR;

namespace GarmentShop.Application.Common.CQRS
{
    public interface ICommandHandler<TCommand> 
        : IRequestHandler<TCommand, Error> where TCommand : ICommand
    {
    }

    public interface ICommandHandler<TCommand, TResponse>
        : IRequestHandler<TCommand, ErrorOr<TResponse>>  
            where TCommand : ICommand<TResponse>
    { 
    }
}
