using ERPDemo.Core.ValueObjects;

namespace ERPDemo.Core.Entities.Base
{
    public abstract class Entity<TEntityId> : IEntity<TEntityId>
        where TEntityId : IEntityId
    {
        public TEntityId Id { get; protected set; }
    }
}
