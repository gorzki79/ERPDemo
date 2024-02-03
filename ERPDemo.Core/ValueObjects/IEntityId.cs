namespace ERPDemo.Core.ValueObjects
{
    public interface IEntityId
    {

    }

    public interface IEntityId<T> : IEntityId
    {
        T Value { get; }
    }
}
