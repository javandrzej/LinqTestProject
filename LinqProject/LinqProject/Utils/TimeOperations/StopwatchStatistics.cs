using LinqProject.Utils.TimeOperations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqProject.Utils
{
    public class StopwatchStatistics : IStatistics, StatisticsOperations
    {
        private List<TimeSpan> watchList = new List<TimeSpan>();

        public void AddTimeToList(TimeSpan time)
        {
            watchList.Add(time);
        }

        public void ClearList()
        {
            watchList.Clear();
        }

        public decimal CalculateAverage()
        {
            return watchList.Average(element => Convert.ToDecimal(element.Ticks));
        }

        public decimal CalculateMaxTime()
        {
            return watchList.Max(element => Convert.ToDecimal(element.Ticks));
        }

        public decimal CalculateMinTime()
        {
            return watchList.Min(element => Convert.ToDecimal(element.Ticks));
        }

        public void WriteStatistics()
        {
            Console.WriteLine();
            Console.Write("Average time = ");
            StopwatchUtil.FormatTimeSpan(new TimeSpan(Convert.ToInt32(CalculateAverage())));
            Console.Write("Max time = ");
            StopwatchUtil.FormatTimeSpan(new TimeSpan(Convert.ToInt32(CalculateMaxTime())));
            Console.Write("Min time = ");
            StopwatchUtil.FormatTimeSpan(new TimeSpan(Convert.ToInt32(CalculateMinTime())));
        }


    }
}
