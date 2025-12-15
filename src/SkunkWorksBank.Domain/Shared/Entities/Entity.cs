namespace SkunkWorksBank.Domain.Shared.Entities
{
    public abstract class Entity(Guid id) : IEquatable<Guid>
    {
        public Guid Id { get; } = id;

        public bool Equals(Guid other) => Id == Id;
    }
}
