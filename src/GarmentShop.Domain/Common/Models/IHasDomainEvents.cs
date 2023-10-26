using GarmentShop.Domain.Common.Events;

namespace GarmentShop.Domain.Common.Models
{
    public interface IHasDomainEvents
    {
        IReadOnlyList<IDomainEvent> GetDomainEvents();
        void ClearDomainEvents();
    }
}
