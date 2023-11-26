using GarmentShop.Application.Common.Interfaces.Persistance.CommonRepositories;
using GarmentShop.Application.Common.Services;
using GarmentShop.Domain.Common.Events;
using GarmentShop.Domain.Events.Garment;
using GarmentShop.Domain.GarmentAggregate;
using GarmentShop.Domain.GarmentAggregate.ValueObjects;
using Microsoft.Extensions.Logging;

namespace GarmentShop.Application.Garments.Events
{
    public sealed class GarmentDeletedEventHandler
        : IDomainEventHandler<GarmentDeletedEvent>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<GarmentDeletedEventHandler> logger;
        private readonly IDateTimeProvider dateTimeProvider;

        public GarmentDeletedEventHandler(
            IUnitOfWork unitOfWork,
            ILogger<GarmentDeletedEventHandler> logger,
            IDateTimeProvider dateTimeProvider)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;
            this.dateTimeProvider = dateTimeProvider;
        }

        public async Task Handle(
            GarmentDeletedEvent notification,
            CancellationToken cancellationToken)
        {
            var garmentDeleted = await unitOfWork
                .GetRepository<Garment, GarmentId>()
                .GetByIdAsync(
                    GarmentId.Create(notification.GarmentId),
                    cancellationToken);

            if (garmentDeleted is null)
            {
                logger.LogInformation(
                    "Deleted garment is not found in database " +
                    "during deleting. {@DateTimeUtc}",
                    dateTimeProvider.UtcNow);

                return;
            }

            logger.LogInformation(
                "Deleted garment GarmentId: {@GarmentId}, Date: {@DateTimeUtc}",
                garmentDeleted.Id.Value, dateTimeProvider.UtcNow);

            return;
        }
    }
}