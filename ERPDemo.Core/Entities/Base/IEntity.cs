using ERPDemo.Core.ValueObjects;

namespace ERPDemo.Core.Entities.Base
{
    public interface IEntity
    {
    }

    public interface IEntity<TEntityId> : IEntity
        where TEntityId : IEntityId
    {
        TEntityId Id { get; }
    }
}
