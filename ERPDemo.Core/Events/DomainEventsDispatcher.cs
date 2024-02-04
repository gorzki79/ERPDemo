using ERPDemo.Core.Entities.Base;
using Microsoft.Extensions.DependencyInjection;

namespace ERPDemo.Core.Events
{
    public class DomainEventsDispatcher : IDomainEventsDispatcher
    {
        private readonly IServiceScopeFactory serviceScopeFactory;

        public DomainEventsDispatcher(IServiceScopeFactory serviceScopeFactory)
        {
            this.serviceScopeFactory = serviceScopeFactory;
        }

        public async Task DispatchDomainEventsAsync<T>(T entity)
            where T : class, IAggregatedRoot
        {
            var domainEvents = entity.DomainEvents.ToList();

            var tasks = domainEvents
                .Select((domainEvent) =>
                {
                    Type type = domainEvent.GetType();
                    var func = typeof(IDomainEventsDispatcher).GetMethod("DispatchDomainEventAsync")?.MakeGenericMethod(type);
                    var task = (Task)(func?.Invoke(this, new[] { domainEvent }) ?? Task.CompletedTask);
                    return task;
                });

            await Task.WhenAll(tasks);
            entity.ClearDomainEvents();
        }

        public async Task DispatchDomainEventAsync<T>(T @event)
            where T : class, IDomainEvent
        {
            using (var scope = serviceScopeFactory.CreateScope())
            {
                var handlers = (IEnumerable<IDomainEventHandler<T>>)scope.ServiceProvider.GetServices(typeof(IDomainEventHandler<T>));
                var handlersTasks = handlers.Select((h) => h.HandleAsync(@event));
                await Task.WhenAll(handlersTasks);
            }
        }
    }
}
