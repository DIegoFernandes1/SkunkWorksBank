using SkunkWorksBank.API.tests.Mocks;
using SkunkWorksBank.Domain.Users.ValueObjects;

namespace SkunkWorksBank.API.tests.Users.ValueObjects
{
    public class TrackerTest
    {
        private readonly FakeDateTimeProvider _dateTimeProvider = new FakeDateTimeProvider();

        [Fact]
        public void ShouldCreateTrackerWithCurrentUtcDateTime()
        {
            var tracker = Tracker.Create(_dateTimeProvider);

            Assert.Equal(_dateTimeProvider.UtcNow, tracker.CreatedAt);
        }

        [Fact]
        public void ShouldCreateTrackerWithDateTime()
        {
            var createdAt = DateTime.UtcNow;

            var tracker = Tracker.Create(createdAt, createdAt);

            Assert.Equal(createdAt, tracker.CreatedAt);
        }

        [Fact]
        public void ShouldUpdateDate()
        {
            var tracker = Tracker.Create(_dateTimeProvider);

            _dateTimeProvider.Advance(new TimeSpan(4,2,45,32));
            tracker.Update(_dateTimeProvider);

            Assert.Equal(_dateTimeProvider.UtcNow, tracker.UpdatedAt);
        }
    }
}
