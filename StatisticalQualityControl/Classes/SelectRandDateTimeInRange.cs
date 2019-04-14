using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static StatisticalQualityControl.Services.SingletonRandom;

namespace StatisticalQualityControl.Classes
{
    public static class SelectRandDateTimeInRange
    {
        public static DateTime SelectDateTime(DateTime dateRangeStart, DateTime dateRangeEnd)
        {
            if (dateRangeStart == dateRangeEnd)
            {
                return dateRangeStart;
            }
            int rangeTotalDay = dateRangeEnd.Day - dateRangeEnd.Day;

            int selectDay = Rnd.Next(0, rangeTotalDay + 1);

            return dateRangeStart.AddDays(selectDay);
        }
    }
}