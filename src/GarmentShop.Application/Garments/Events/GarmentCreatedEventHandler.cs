using GarmentShop.Application.Common.Interfaces.Persistance.CommonRepositories;
using GarmentShop.Application.Common.Services;
using GarmentShop.Domain.Common.Events;
using GarmentShop.Domain.Events.Garment;
using GarmentShop.Domain.GarmentAggregate;
using GarmentShop.Domain.GarmentAggregate.ValueObjects;
using Microsoft.Extensions.Logging;

namespace GarmentShop.Application.Garments.Events
{
    public sealed class GarmentCreatedEventHandler
        : IDomainEventHandler<GarmentCreatedEvent>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<GarmentCreatedEventHandler> logger;
        private readonly IDateTimeProvider dateTimeProvider;

        public GarmentCreatedEventHandler(
            IUnitOfWork unitOfWork,
            ILogger<GarmentCreatedEventHandler> logger,
            IDateTimeProvider dateTimeProvider)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;
            this.dateTimeProvider = dateTimeProvider;
        }

        public async Task Handle(
            GarmentCreatedEvent notification,
            CancellationToken cancellationToken)
        {
            var garmentCreated = await unitOfWork
                .GetRepository<Garment, GarmentId>()
                .GetByIdAsync(
                    GarmentId.Create(notification.GarmentId),
                    cancellationToken);

            if (garmentCreated is null)
            {
                logger.LogInformation(
                    "Created garment is not found in database " +
                    "during creating. {@DateTimeUtc}",
                    dateTimeProvider.UtcNow);

                return;
            }

            logger.LogInformation(
                "Created garment GarmentId: {@GarmentId}, Date: {@DateTimeUtc}",
                garmentCreated.Id.Value, dateTimeProvider.UtcNow);

            return;
        }
    }
}
