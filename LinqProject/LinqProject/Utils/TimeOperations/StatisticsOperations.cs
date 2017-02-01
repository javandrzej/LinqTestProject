using System;

namespace LinqProject.Utils.TimeOperations
{
    public interface StatisticsOperations
    {
        void AddTimeToList(TimeSpan time);
        void ClearList();
        void WriteStatistics();

    }
}
