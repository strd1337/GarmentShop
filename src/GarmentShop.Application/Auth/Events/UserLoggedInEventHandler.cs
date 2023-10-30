using GarmentShop.Application.Common.Interfaces.Persistance.CommonRepositories;
using GarmentShop.Application.Common.Services;
using GarmentShop.Domain.AuthenticationAggregate;
using GarmentShop.Domain.AuthenticationAggregate.ValueObjects;
using GarmentShop.Domain.Common.Events;
using GarmentShop.Domain.Events.Auth;
using Microsoft.Extensions.Logging;

namespace GarmentShop.Application.Auth.Events
{
    public sealed class UserLoggedInEventHandler
        : IDomainEventHandler<UserLoggedInEvent>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<UserLoggedInEventHandler> logger;
        private readonly IDateTimeProvider dateTimeProvider;

        public UserLoggedInEventHandler(
            IUnitOfWork unitOfWork, 
            ILogger<UserLoggedInEventHandler> logger, 
            IDateTimeProvider dateTimeProvider)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;
            this.dateTimeProvider = dateTimeProvider;
        }

        public async Task Handle(
            UserLoggedInEvent notification, 
            CancellationToken cancellationToken)
        {
            var loggingInUser = await unitOfWork
               .GetRepository<Authentication, AuthenticationId>()
               .GetByIdAsync(
                     AuthenticationId.Create(notification.AuthId),
                     cancellationToken);

            if (loggingInUser is null)
            {
                logger.LogInformation(
                    "User is not found in database during logging in. {@DateTimeUtc}",
                    dateTimeProvider.UtcNow);

                return;
            }

            logger.LogInformation(
                "User logged in AuthId: {@AuthId}, " +
                "UserId: {@UserId}, Date: {@DateTimeUtc}",
                loggingInUser.Id.Value, loggingInUser.UserId.Value, 
                dateTimeProvider.UtcNow);

            return;
        }
    }
}
