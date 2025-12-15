using SkunkWorksBank.Domain.Shared.Abstractions;

namespace SkunkWorksBank.API.tests.Mocks
{
    public class FakeDateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => new(2025, 1, 2, 3, 45, 32, DateTimeKind.Utc);

        public void Advance(TimeSpan time) => UtcNow.Add(time);
    }
}
