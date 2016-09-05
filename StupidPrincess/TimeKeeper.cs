using System;
using System.Diagnostics;
using System.Threading;

namespace StupidPrincess
{
    public class TimeKeeper
    {
        private readonly int _millisecondsPerFrame;
        private readonly Stopwatch _stopwatch;

        public TimeKeeper(int framesPerSecond) {
            _millisecondsPerFrame = (int)(1000.0 / framesPerSecond);
            _stopwatch = Stopwatch.StartNew();
        }

        public TimeSpan WaitForUpdate() {
            var elapsed = _stopwatch.ElapsedMilliseconds;
            var delta = elapsed - _millisecondsPerFrame;

            if (delta > 0) {
                _stopwatch.Restart();
                return TimeSpan.FromMilliseconds(elapsed);
            }

            Thread.Sleep(TimeSpan.FromMilliseconds(-delta));

            _stopwatch.Restart();
            return TimeSpan.FromMilliseconds(_millisecondsPerFrame);
        }
    }
}