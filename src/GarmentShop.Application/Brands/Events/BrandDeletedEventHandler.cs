using GarmentShop.Application.Common.Interfaces.Persistance.CommonRepositories;
using GarmentShop.Application.Common.Services;
using GarmentShop.Domain.BrandAggregate;
using GarmentShop.Domain.BrandAggregate.ValueObjects;
using GarmentShop.Domain.Common.Events;
using GarmentShop.Domain.Events.Brand;
using Microsoft.Extensions.Logging;

namespace GarmentShop.Application.Brands.Events
{
    public sealed class BrandDeletedEventHandler
        : IDomainEventHandler<BrandDeletedEvent>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<BrandDeletedEventHandler> logger;
        private readonly IDateTimeProvider dateTimeProvider;

        public BrandDeletedEventHandler(
            IUnitOfWork unitOfWork,
            ILogger<BrandDeletedEventHandler> logger,
            IDateTimeProvider dateTimeProvider)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;
            this.dateTimeProvider = dateTimeProvider;
        }

        public async Task Handle(
            BrandDeletedEvent notification,
            CancellationToken cancellationToken)
        {
            var brandDeleted = await unitOfWork
                .GetRepository<Brand, BrandId>()
                .GetByIdAsync(
                    BrandId.Create(notification.BrandId),
                    cancellationToken);

            if (brandDeleted is null)
            {
                logger.LogInformation(
                    "Deleted brand is not found in database " +
                    "during creating. {@DateTimeUtc}",
                    dateTimeProvider.UtcNow);

                return;
            }

            logger.LogInformation(
                "Deleted brand BrandId: {@BrandId}, Date: {@DateTimeUtc}",
                brandDeleted.Id.Value, dateTimeProvider.UtcNow);

            return;
        }
    }
}
