using LinqProject.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LinqProjectTests
{
    [TestClass]
    public class SpeedTests
    {
        [TestMethod]
        public void TestTime()
        {
            var numberOfExecutingTests = 40;
            StopwatchStatistics statistics = new StopwatchStatistics();
            for (int j = 0; j < numberOfExecutingTests; j++)
            {
                Action<int, int> calulatePow = ((a, b) =>
            {
                int sum = 0;
                for (int i = Math.Min(a, b); i <= Math.Max(a, b); i++)
                {
                    sum += i;
                }
            });
                var calculatedTime = StopwatchUtil.Time(() => calulatePow(10, 1000000));
                statistics.AddTimeToList(calculatedTime);
                StopwatchUtil.FormatTimeSpan(calculatedTime, j);
            }
            statistics.WriteStatistics();
        }
    }
}
