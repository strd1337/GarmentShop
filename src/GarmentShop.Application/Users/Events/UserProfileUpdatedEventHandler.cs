using GarmentShop.Application.Common.Interfaces.Persistance.CommonRepositories;
using GarmentShop.Application.Common.Services;
using GarmentShop.Domain.Common.Events;
using GarmentShop.Domain.Events.User;
using GarmentShop.Domain.UserAggregate;
using GarmentShop.Domain.UserAggregate.ValueObjects;
using Microsoft.Extensions.Logging;

namespace GarmentShop.Application.Users.Events
{
    public sealed class UserProfileUpdatedEventHandler :
        IDomainEventHandler<UserProfileUpdatedEvent>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<UserProfileUpdatedEventHandler> logger;
        private readonly IDateTimeProvider dateTimeProvider;

        public UserProfileUpdatedEventHandler(
            IUnitOfWork unitOfWork,
            ILogger<UserProfileUpdatedEventHandler> logger,
            IDateTimeProvider dateTimeProvider)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;
            this.dateTimeProvider = dateTimeProvider;
        }

        public async Task Handle(
            UserProfileUpdatedEvent notification,
            CancellationToken cancellationToken)
        {
            var user = await unitOfWork
               .GetRepository<User, UserId>()
               .GetByIdAsync(
                    UserId.Create(notification.UserId),
                    cancellationToken);

            if (user is null)
            {
                logger.LogInformation(
                    "User is not found in database during updating profile. " +
                    "{@DateTimeUtc}", dateTimeProvider.UtcNow);

                return;
            }

            logger.LogInformation(
                "User updated own profile UserId: {@UserId}, " +
                "FirstName: {@FirstName}, LastName: {@LastName}, " +
                "PhoneNumber: {@PhoneNumber}, Address: {@Address}, " +
                "City: {@City}, ZipCode: {@ZipCode}, Country: {@Country}, " +
                "Date: {@DateTimeUtc}", notification.UserId, notification.FirstName, 
                notification.LastName, notification.PhoneNumber, notification.Address, 
                notification.City, notification.ZipCode, notification.Country,
                dateTimeProvider.UtcNow);

            return;
        }
    }
}