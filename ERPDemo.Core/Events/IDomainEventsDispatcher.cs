using ERPDemo.Core.Entities.Base;

namespace ERPDemo.Core.Events
{
    public interface IDomainEventsDispatcher
    {
        Task DispatchDomainEventsAsync<T>(T entity)
            where T : class, IAggregatedRoot;
        Task DispatchDomainEventAsync<TEvent>(TEvent @event)
            where TEvent : class, IDomainEvent;
    }
}
