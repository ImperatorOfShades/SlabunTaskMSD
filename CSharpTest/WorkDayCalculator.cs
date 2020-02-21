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
                int comparation1, comparation2, weekEndsDuration;
                enddate = startDate;
                enddate = enddate.AddDays(dayCount - 1);
                foreach (var weekEnd in weekEnds)
                {
                    comparation1 = DateTime.Compare(startDate, weekEnd.EndDate);
                    comparation2 = DateTime.Compare(weekEnd.StartDate, startDate);
                    if (comparation1 <= 0 && comparation2 <= 0)
                    {
                        dateDifference = weekEnd.EndDate - startDate;
                        weekEndsDuration = dateDifference.Days + 1;
                        enddate = enddate.AddDays(weekEndsDuration);
                    }

                    comparation1 = DateTime.Compare(enddate, weekEnd.StartDate);
                    comparation2 = DateTime.Compare(startDate, weekEnd.StartDate);
                    if (comparation1 >= 0 && comparation2 <0)
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
