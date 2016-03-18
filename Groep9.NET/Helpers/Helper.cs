using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Groep9.NET.Helpers
{
    public static class Helper
    {


        public static DateTime BerekenStartDatumReservatieWeek(DateTime date)
        {
            if (BerekenWeek(date) == BerekenWeek(DateTime.Today)) {

                // returnt datum van volgende week
                if (date.DayOfWeek >= DayOfWeek.Monday && date.DayOfWeek <= DayOfWeek.Thursday ||
                    (date.DayOfWeek == DayOfWeek.Friday && DateTime.Now.Hour < 17)) {
                    int daysUntilMonday = (((int)DayOfWeek.Monday - (int)date.DayOfWeek + 7) % 7);
                    return date.AddDays(daysUntilMonday).AddHours(8);
                }
                else {
                    // returnt datum van volgende volgende week (indien na vrijdag 17h)
                    int daysUntilMonday = (((int)DayOfWeek.Monday - (int)date.DayOfWeek + 7) % 7 + 7);
                    return date.AddDays(daysUntilMonday).AddHours(8);
                }

                //throw new ArgumentException("kan niet reserveren voor deze week, selecteer ten vroegste volgende week");

            }

            int daysAfterMonday = (int)DayOfWeek.Monday - (int)date.DayOfWeek;
            return date.AddDays(daysAfterMonday).AddHours(8);
        }

        public static DateTime BerekenEindDatumReservatieWeek(DateTime date) {
            return BerekenStartDatumReservatieWeek(date).AddDays(4).AddHours(9);
        }


        public static int BerekenWeek(DateTime date)
        {
            var currentCulture = CultureInfo.CurrentCulture;
            var weekNo = currentCulture.Calendar.GetWeekOfYear(
                             //haalt jaar, maand en dag uit string en zet om in int
                             new DateTime(date.Year, date.Month, date.Day),
                            currentCulture.DateTimeFormat.CalendarWeekRule,
                            currentCulture.DateTimeFormat.FirstDayOfWeek);

            // YYYY/MM/DD
            // MM/DD/YYYY
            return weekNo;
        }

        public static DateTime ZetDatumOm(string datum) {
            if (datum == null) {
                //als er geen datum geselecteerd is, stel tempdata in op vandaag
                datum = DateTime.ParseExact(DateTime.Today.ToString().Substring(0, 10), "dd/MM/yyyy", null).ToString("dd/MM/yyyy");

            }
            return new DateTime(Int32.Parse(datum.Substring(6, 4)), Int32.Parse(datum.Substring(3, 2)), Int32.Parse(datum.Substring(0, 2)));
        }
    }
}