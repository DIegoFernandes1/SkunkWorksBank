namespace SkunkWorksBank.Domain.Shared.Entities
{
    public abstract class Entity<TId>(TId id) : IEquatable<Entity<TId>> where TId : notnull
    {
        public TId Id { get; } = id;

        public bool Equals(Entity<TId> other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return EqualityComparer<TId>.Default.Equals(Id, other.Id);
        }
    }
}
