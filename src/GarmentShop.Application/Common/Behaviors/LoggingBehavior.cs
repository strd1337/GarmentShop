using ErrorOr;
using GarmentShop.Application.Common.Services;
using MediatR;
using Microsoft.Extensions.Logging;

namespace GarmentShop.Application.Common.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
            where TRequest : IRequest<TResponse>
            where TResponse : IErrorOr
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> logger;
        private readonly IDateTimeProvider dateTimeProvider;

        public LoggingBehavior(
            ILogger<LoggingBehavior<TRequest, TResponse>> logger,
            IDateTimeProvider dateTimeProvider)
        {
            this.logger = logger;
            this.dateTimeProvider = dateTimeProvider;
        }

        public async Task<TResponse> Handle(
            TRequest request, 
            RequestHandlerDelegate<TResponse> next, 
            CancellationToken cancellationToken)
        {
            logger.LogInformation(
                "Start request {@RequestName}, {@DateTimeUtc}",
                typeof(TRequest).Name, dateTimeProvider.UtcNow);
            
            var loggerResult = await next();

            if (loggerResult.IsError)
            {
                var errors = loggerResult.Errors!
                  .ConvertAll(loggerFailure => Error.Failure(
                      loggerFailure.Description,
                      loggerFailure.Code));

                foreach(var error in errors)
                {
                    logger.LogError("Request error " +
                        "{@RequestName}, " +
                        "{@Error}, " +
                        "{@DateTimeUtc}",
                        typeof(TRequest).Name,
                        error,
                        dateTimeProvider.UtcNow);
                }
            }

            logger.LogInformation(
                "Completed request {@RequestName}, {@DateTimeUtc}",
                typeof(TRequest).Name, dateTimeProvider.UtcNow);

            return loggerResult;
        }
    }
}
