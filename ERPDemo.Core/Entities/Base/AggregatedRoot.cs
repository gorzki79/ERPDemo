using ERPDemo.Core.ValueObjects;

namespace ERPDemo.Core.Entities.Base
{
    public abstract class AggregatedRoot<TAggregatedId> : Entity<TAggregatedId>, IAggregatedRoot
            where TAggregatedId : IEntityId
    {
    }
}
