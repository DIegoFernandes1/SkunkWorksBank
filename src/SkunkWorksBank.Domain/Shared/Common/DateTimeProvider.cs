using SkunkWorksBank.Domain.Shared.Abstractions;

namespace SkunkWorksBank.Domain.Shared.Common
{
    public sealed class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow { get; } = DateTime.UtcNow;
    }
}
