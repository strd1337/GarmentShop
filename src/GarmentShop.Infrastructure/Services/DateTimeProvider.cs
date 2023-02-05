using GarmentShop.Application.Common.Services;

namespace GarmentShop.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.Now;
    }
}
