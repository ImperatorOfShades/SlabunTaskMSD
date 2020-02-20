using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    public class WorkDayCalculator : IWorkDayCalculator
    {
        public DateTime Calculate(DateTime startDate, int dayCount, WeekEnd[] weekEnds)
        {
            DateTime enddate;
            if (weekEnds != null)
            {
                TimeSpan dateDifference;
                int comparation, weekEndsDuration;
                enddate = startDate.AddDays(dayCount - 1);
                foreach (var weekEnd in weekEnds)
                {
                    comparation = DateTime.Compare(enddate, weekEnd.StartDate);
                    if (comparation >= 0)
                    {
                        dateDifference = weekEnd.EndDate - weekEnd.StartDate;
                        weekEndsDuration = dateDifference.Days + 1;
                        enddate = enddate.AddDays(weekEndsDuration);
                    }
                }
            }
            else
                enddate = startDate.AddDays(dayCount - 1);

            return enddate;

            throw new NotImplementedException();
        }
    }
}
