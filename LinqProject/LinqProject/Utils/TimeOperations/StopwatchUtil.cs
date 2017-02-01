using System;
using System.Diagnostics;

namespace LinqProject.Utils
{
    public static class StopwatchUtil
    {
        public static TimeSpan Time(Action action)
        {
            Stopwatch watch = Stopwatch.StartNew();
            action();
            watch.Stop();
            return watch.Elapsed;
        }

        public static void Time(object v)
        {
            throw new NotImplementedException();
        }

        public static void FormatTimeSpan(TimeSpan time)
        {
            Console.WriteLine("Time as date " + time.Days + " Days " + time.Hours + " Hours " + time.Minutes + " Minutes " + time.Milliseconds + " Miliseconds " + " Total miliseconds " + time.TotalMilliseconds + " Total ticks " + time.Ticks);
        }

        public static void FormatTimeSpan(TimeSpan time, int iteration)
        {
            Console.Write("Iteration " + iteration + " ");
            FormatTimeSpan(time);
        }

    }
}
