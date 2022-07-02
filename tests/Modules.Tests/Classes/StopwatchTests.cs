using Classes.Module.StopwatchContext;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Modules.Tests.Classes
{
    public class StopwatchTests
    {
        [Theory(DisplayName = "Should have N seconds of duration")]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public async void SecondsDuration(int duration)
        {
            var stopwatch = new Stopwatch();
            var expectedDuration = duration;

            stopwatch.Start();
            await Task.Delay(TimeSpan.FromSeconds(duration));
            stopwatch.Stop();

            var currentDurationInSeconds = stopwatch.CurrentDuration();
            var totalDurationInSeconds = stopwatch.TotalDuration();

            Assert.Equal(expectedDuration, currentDurationInSeconds);
            Assert.Equal(expectedDuration, totalDurationInSeconds);
        }

        [Theory(DisplayName = "Should have N seconds of total duration")]
        [InlineData(0, 1)]
        [InlineData(1, 2)]
        [InlineData(2, 3)]
        [InlineData(3, 4)]
        [InlineData(4, 5)]
        [InlineData(5, 6)]
        public async void SecondsTotalDuration(int firstDuration, int secondDuration)
        {
            var stopwatch = new Stopwatch();
            var expectedDuration = firstDuration + secondDuration;

            stopwatch.Start();
            await Task.Delay(firstDuration * 1000);
            stopwatch.Stop();

            stopwatch.Start();
            await Task.Delay(secondDuration * 1000);
            stopwatch.Stop();

            var totalDurationInSeconds = stopwatch.TotalDuration();

            Assert.Equal(expectedDuration, totalDurationInSeconds);
        }

        [Fact(DisplayName = "Should return 0 minutes when stopwatch has run by less than a minute")]
        public async Task LessThanAMinute()
        {
            var stopwatch = new Stopwatch();
            var expectedDuration = 0;

            stopwatch.Start();
            await Task.Delay(2000);
            stopwatch.Stop();

            var currentDurationInMinutes = stopwatch.CurrentDuration(StopwatchDurationFormat.Minutes);
            var totalDurationInMinutes = stopwatch.TotalDuration(StopwatchDurationFormat.Minutes);

            Assert.Equal(expectedDuration, currentDurationInMinutes);
            Assert.Equal(expectedDuration, totalDurationInMinutes);
        }

        [Fact(DisplayName = "Should return 0 hours when stopwatch has run by less than an hour")]
        public async Task LessThanAnHour()
        {
            var stopwatch = new Stopwatch();
            var expectedDuration = 0;

            stopwatch.Start();
            await Task.Delay(1300);
            stopwatch.Stop();

            var currentDurationInMinutes = stopwatch.CurrentDuration(StopwatchDurationFormat.Hours);
            var totalDurationInMinutes = stopwatch.TotalDuration(StopwatchDurationFormat.Hours);

            Assert.Equal(expectedDuration, currentDurationInMinutes);
            Assert.Equal(expectedDuration, totalDurationInMinutes);
        }

        [Fact(DisplayName = "Should return 0 days when stopwatch has run by less than a day")]
        public async Task LessThanADay()
        {
            var stopwatch = new Stopwatch();
            var expectedDuration = 0;

            stopwatch.Start();
            await Task.Delay(1500);
            stopwatch.Stop();

            var currentDurationInMinutes = stopwatch.CurrentDuration(StopwatchDurationFormat.Days);
            var totalDurationInMinutes = stopwatch.TotalDuration(StopwatchDurationFormat.Days);

            Assert.Equal(expectedDuration, currentDurationInMinutes);
            Assert.Equal(expectedDuration, totalDurationInMinutes);
        }

        [Fact(DisplayName = "Should throw an InvalidOperationException when started twice in a row")]
        public void TwiceInARow()
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();

            Assert.Throws<InvalidOperationException>(() => stopwatch.Start());
        }

        [Fact(DisplayName = "Should throw an InvalidOperationException when trying to stop without starting")]
        public void StopWithoutStarting()
        {
            var stopwatch = new Stopwatch();

            Assert.Throws<InvalidOperationException>(() => stopwatch.Stop());
        }
    }
}
