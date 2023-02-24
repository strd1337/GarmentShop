using GarmentShop.Domain.Common.Models;
using MediatR;

namespace GarmentShop.Domain.Common.Events
{
    public interface IDomainEvent : INotification
    {
    }
}
