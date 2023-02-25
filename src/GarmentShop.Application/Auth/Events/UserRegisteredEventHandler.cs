using GarmentShop.Application.Common.Interfaces.Persistance.CommonRepositories;
using GarmentShop.Application.Common.Services;
using GarmentShop.Domain.AuthenticationAggregate;
using GarmentShop.Domain.AuthenticationAggregate.ValueObjects;
using GarmentShop.Domain.Common.Events;
using GarmentShop.Domain.Events.Auth;
using Microsoft.Extensions.Logging;

namespace GarmentShop.Application.Auth.Events
{
    public sealed class UserRegisteredEventHandler
        : IDomainEventHandler<UserRegisteredEvent>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<UserRegisteredEventHandler> logger;
        private readonly IDateTimeProvider dateTimeProvider;

        public UserRegisteredEventHandler(
            IUnitOfWork unitOfWork,
            ILogger<UserRegisteredEventHandler> logger,
            IDateTimeProvider dateTimeProvider)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;
            this.dateTimeProvider = dateTimeProvider;
        }

        public async Task Handle(
            UserRegisteredEvent notification,
            CancellationToken cancellationToken)
        {
            var registeredUser = await unitOfWork
               .GetRepository<Authentication, AuthenticationId>()
               .GetByIdAsync(
                    AuthenticationId.Create(notification.AuthId),
                    cancellationToken);

            if (registeredUser is null)
            {
                logger.LogInformation(
                    "Registered user is not found in database " +
                    "during registration. {@DateTimeUtc}",
                    dateTimeProvider.UtcNow);

                return;
            }

            logger.LogInformation(
                "User registered AuthId: {@AuthId}, " +
                "UserId: {@UserId}, Date: {@DateTimeUtc}",
                registeredUser.Id.Value, registeredUser.UserId.Value, 
                dateTimeProvider.UtcNow);

            return;
        }
    }
}
