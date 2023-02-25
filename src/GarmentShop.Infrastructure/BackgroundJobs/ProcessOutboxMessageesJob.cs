using GarmentShop.Application.Common.Services;
using GarmentShop.Domain.Common.Events;
using GarmentShop.Domain.Common.Outbox;
using GarmentShop.Infrastructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Quartz;
using Polly;

namespace GarmentShop.Infrastructure.BackgroundJobs
{
    [DisallowConcurrentExecution]
    public class ProcessOutboxMessageesJob : IJob
    {
        private readonly GarmentShopDbContext dbContext;
        private readonly IPublisher publisher;
        private readonly IDateTimeProvider dateTimeProvider;

        public ProcessOutboxMessageesJob(
            GarmentShopDbContext dbContext, 
            IPublisher publisher,
            IDateTimeProvider dateTimeProvider)
        {
            this.dbContext = dbContext;
            this.publisher = publisher;
            this.dateTimeProvider = dateTimeProvider;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            var messages = await dbContext
                .Set<OutboxMessage>()
                .Where(m => m.ProcessedOnUtc == null)
                .OrderBy(m => m.OccurredOnUtc)
                .Take(20)
                .ToListAsync(context.CancellationToken);

            foreach(var message in messages)
            {
                IDomainEvent? domainEvent = JsonConvert
                    .DeserializeObject<IDomainEvent>(
                    message.Content,
                    new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.All
                    });

                if (domainEvent is null)
                {
                    continue;
                }

                var policy = Policy
                    .Handle<Exception>()
                    .WaitAndRetryAsync(
                        3,
                        attempt => TimeSpan.FromMicroseconds(50 * attempt));

                var result = await policy.ExecuteAndCaptureAsync(() =>
                    publisher.Publish(
                        domainEvent, 
                        context.CancellationToken));

                message.Error = result.FinalException?.ToString();
                message.ProcessedOnUtc = dateTimeProvider.UtcNow;
            }

            await dbContext.SaveChangesAsync();
        }
    }
}
