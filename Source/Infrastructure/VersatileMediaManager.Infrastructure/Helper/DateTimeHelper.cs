using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VersatileMediaManager.Infrastructure.Helper
{
    public static class DateTimeHelper
    {
        /// <summary>
        /// Convert UNIX-Time to local DateTime
        /// </summary>
        /// <param name="unixTime">Number of seconds since the Unix Epoch (1st of January 1970 00:00:00 GMT)</param>
        /// <returns></returns>
        public static DateTime UnixTimeToDateTime(ulong unixTime)
        {
            DateTime result = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            
            return result.AddSeconds(unixTime).ToLocalTime();
        }

        /// <summary>
        /// Converts a DateTime to seconds since the Unix Epoch (1st of January 1970 00:00:00 GMT)
        /// </summary>
        /// <param name="dateTime">The DateTime to convert</param>
        /// <returns></returns>
        public static long DateTimeToUnixTime(DateTime dateTime)
        {
            DateTime date_time_base = new DateTime(1970, 1, 1, 0, 0, 0, 0);

            TimeSpan span = dateTime.ToUniversalTime() - date_time_base;

            return (long)span.TotalSeconds;
        }
    }
}