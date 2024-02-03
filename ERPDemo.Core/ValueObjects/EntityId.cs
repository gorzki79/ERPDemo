using System.Diagnostics.CodeAnalysis;

namespace ERPDemo.Core.ValueObjects
{
    public class EntityId<T> : IEquatable<EntityId<T>>, IEntityId<T>
    {
        public T Value { get; }


        public EntityId(T value)
        {
            this.Value = value;
        }

        public bool Equals([AllowNull] EntityId<T> other)
        {
            if (ReferenceEquals(null, other)) 
                return false;
            return ReferenceEquals(this, other) || (this.Value is not null && this.Value.Equals(other.Value));
        }

        public override int GetHashCode()
        {
            return this.Value is null ? 0 : this.Value.GetHashCode();
        }
    }
}
