using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Utility
{
    public static class PersianDateCalender
    {
        public static string ToPersian(DateTime date)
        {
            PersianCalendar pc = new PersianCalendar();
            var m = pc.GetMonth(date).ToString().Length < 2 ? "0" + pc.GetMonth(date).ToString() : pc.GetMonth(date).ToString();
            var d = pc.GetDayOfMonth(date).ToString().Length < 2 ? "0" + pc.GetDayOfMonth(date).ToString() : pc.GetDayOfMonth(date).ToString();
            var y = pc.GetYear(date).ToString();
            return $"{y}/{m}/{d}";
        }
        public static string ToPersian(DateTime? date)
        {
            
            return "";
        }
    }
}
