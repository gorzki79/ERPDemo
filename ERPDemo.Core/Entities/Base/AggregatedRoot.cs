using ERPDemo.Core.Events;
using ERPDemo.Core.ValueObjects;

namespace ERPDemo.Core.Entities.Base
{
    public abstract class AggregatedRoot<TAggregatedId> : Entity<TAggregatedId>, IAggregatedRoot
            where TAggregatedId : IEntityId
    {
        private List<IDomainEvent>? domainEvents;

        public List<IDomainEvent> DomainEvents
        {
            get
            {
                this.domainEvents ??= new List<IDomainEvent>();
                return this.domainEvents;
            }
        }

        protected void AddDomainEvent(IDomainEvent @event)
        {
            this.DomainEvents.Add(@event);
        }

        public void ClearDomainEvents()
        {
            this.DomainEvents.Clear();
        }
    }
}
