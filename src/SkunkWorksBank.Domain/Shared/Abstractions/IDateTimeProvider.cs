namespace SkunkWorksBank.Domain.Shared.Abstractions
{
    public interface IDateTimeProvider
    {
        public DateTime UtcNow { get; }
    }
}
