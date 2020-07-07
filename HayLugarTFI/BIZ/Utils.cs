using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIZ
{
    public class Utils
    {
        public static DateTime GetDateTimeLocal()
        {
            DateTime MyDateTime = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc);
            TimeZoneInfo JOTZ = TimeZoneInfo.FindSystemTimeZoneById("Argentina Standard Time");//Jordan
            MyDateTime = TimeZoneInfo.ConvertTime(MyDateTime, JOTZ);
            return MyDateTime;
        }
    }
}
