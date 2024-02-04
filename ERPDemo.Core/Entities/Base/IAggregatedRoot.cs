using ERPDemo.Core.Events;

namespace ERPDemo.Core.Entities.Base
{
    public interface IAggregatedRoot : IEntity
    {
        List<IDomainEvent> DomainEvents { get; }

        void ClearDomainEvents();
    }
}
