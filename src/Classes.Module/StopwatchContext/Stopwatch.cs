namespace Classes.Module.StopwatchContext
{
    public class Stopwatch
    {
        private TimeSpan _currentStopwatch;
        private TimeSpan _totalStopwatch;
        private DateTime _start;
        private DateTime _stop;
        private bool _isStarted = false;

        public Stopwatch()
        {
            _currentStopwatch = TimeSpan.Zero;
            _totalStopwatch = TimeSpan.Zero;
            _start = DateTime.MinValue;
            _stop = DateTime.MinValue;
        }

        public void Start()
        {
            if (_isStarted)
            {
                throw new InvalidOperationException("It is not possible to start a Stopwatch twice in a row. Please, stop it before trying to start it again.");
            }

            ResetStopwatch();
            _start = DateTime.Now;
            _isStarted = true;
        }

        public void Stop()
        {
            if (!_isStarted)
            {
                throw new InvalidOperationException("It is not possible to stop a Stopwatch wasn't started. Please, start it before trying to stop.");
            }

            _stop = DateTime.Now;
            _currentStopwatch = _stop - _start;
            _totalStopwatch += _currentStopwatch;
            _isStarted = false;
        }

        public double CurrentDuration(StopwatchDurationFormat format = StopwatchDurationFormat.Seconds)
        {
            return GetDurationByFormat(_currentStopwatch, format);
        }

        public double TotalDuration(StopwatchDurationFormat format = StopwatchDurationFormat.Seconds)
        {
            return GetDurationByFormat(_totalStopwatch, format);
        }

        private double GetDurationByFormat(TimeSpan stopwatch, StopwatchDurationFormat format)
        {
            switch (format)
            {
                case StopwatchDurationFormat.Miliseconds:
                    return Math.Truncate(stopwatch.TotalMilliseconds);
                case StopwatchDurationFormat.Seconds:
                    return Math.Truncate(stopwatch.TotalSeconds);
                case StopwatchDurationFormat.Minutes:
                    return Math.Truncate(stopwatch.TotalMinutes);
                case StopwatchDurationFormat.Hours:
                    return Math.Truncate(stopwatch.TotalHours);
                case StopwatchDurationFormat.Days:
                    return Math.Truncate(stopwatch.TotalDays);
                default:
                    throw new ArgumentOutOfRangeException(nameof(format), format, "The Stopwatch Duration Format was invalid.");
            }
        }

        private void ResetStopwatch()
        {
            _currentStopwatch = TimeSpan.Zero;
            _start = DateTime.MinValue;
            _stop = DateTime.MinValue;
        }
    }
}
