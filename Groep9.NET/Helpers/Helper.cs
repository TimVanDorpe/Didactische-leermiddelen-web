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
            //als huidige week gelijk is aan geselecteerde week
            if (BerekenWeek(date) == BerekenWeek(DateTime.Today)) {

                // als het maandag tot donderdag is OF vrijdag & vroeger dan 5 uur
                // return volgende week
                if (date.DayOfWeek >= DayOfWeek.Monday && date.DayOfWeek <= DayOfWeek.Thursday ||
                    (date.DayOfWeek == DayOfWeek.Friday && DateTime.Now.Hour < 17)) {
                    int daysUntilMonday = (((int)DayOfWeek.Monday - (int)date.DayOfWeek + 7) % 7);
                    return date.AddDays(daysUntilMonday).AddHours(8);
                }
                // return binnen 2 weken (indien na vrijdag 5 uur deze week of weekend deze week)
                else {
                    int daysUntilMonday = (((int)DayOfWeek.Monday - (int)date.DayOfWeek + 7) % 7 + 7);
                    return date.AddDays(daysUntilMonday).AddHours(8);
                }

                //throw new ArgumentException("kan niet reserveren voor deze week, selecteer ten vroegste volgende week");

            }
            // indien de geselecteerde week volgende week is, EN het is vrijdag na 5 uur, return binnen 2 weken
            if (BerekenWeek(date) == BerekenWeek(DateTime.Today) +1 && (DateTime.Today.DayOfWeek == DayOfWeek.Friday && DateTime.Now.Hour >= 17)) {
                int daysUntilMonday = (((int)DayOfWeek.Monday - (int)date.DayOfWeek + 7) % 7);
                return date.AddDays(daysUntilMonday).AddHours(8);
            }

            // ALS de gekozen datum niet deze week is of niet volgende week is en de huidige niet vrijdag na 5 uur
            // return dan de gekozen week
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
            if (datum == null)
            {
                //als er geen datum geselecteerd is, stel tempdata in op vandaag
                return DateTime.Today;
               

            }
          
            return new DateTime(Int32.Parse(datum.Substring(6, 4)), Int32.Parse(datum.Substring(3, 2)), Int32.Parse(datum.Substring(0, 2)));
           
            
        }
    }
}