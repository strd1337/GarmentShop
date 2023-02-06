using ErrorOr;
using FluentValidation;
using MediatR;

namespace GarmentShop.Application.Common.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> :  
        IPipelineBehavior<TRequest, TResponse>
            where TRequest : IRequest<TResponse>
            where TResponse : IErrorOr
    {
        private readonly IValidator<TRequest>? validator;
         
        public ValidationBehavior(IValidator<TRequest>? validator = null)
        {
            this.validator = validator;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next, 
            CancellationToken cancellationToken)
        {
            if (validator is null)
            {
                return await next();
            }

            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.IsValid)
            {
                return await next();
            }

            var errors = validationResult.Errors
                .ConvertAll(validationFailure => Error.Validation(
                    validationFailure.PropertyName,
                    validationFailure.ErrorMessage));

            return (dynamic)errors;
        }
    }
}
