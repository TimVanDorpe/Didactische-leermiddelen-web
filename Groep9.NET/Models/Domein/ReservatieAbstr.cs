using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Groep9.NET.Models.Domein
{
    public abstract class ReservatieAbstr
    {
        [DataType(DataType.Date)]
        [Display(Name = "Startdatum")]
        public DateTime StartDatum { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Einddatum")]
        public DateTime EindDatum { get; set; }
        public virtual Product Product { get; set; }
        public int Aantal { get; set; }
        public virtual Gebruiker Gebruiker { get; set; }

        public int ReservatieAbstrId { get; set; }
        //public ReservatieAbstr(Product product, int aantal, Gebruiker gebruiker, string datum)
        //{
        //    Gebruiker = gebruiker;
        //    Product = product;
        //    Aantal = aantal;
        //    StartDatum = BerekenStartDatumReservatieWeek(datum);
        //    EindDatum = BerekenEindDatumReservatieWeek(datum);
        //}




        public DateTime BerekenStartDatumReservatieWeek(DateTime date)
        {
            // DateTime date;


            //else {
            //    date = new DateTime(Int32.Parse(datum.Substring(6, 4)), Int32.Parse(datum.Substring(0, 2)), Int32.Parse(datum.Substring(3, 2)));
            //}

            /*
                ALS date.week = dateTime.today.week
                    code hieronder
                ANDERS
                    return de geselecteerde week
            */

            // als de gewenste datum al gepasseerd is
            if (date < DateTime.Today)
            {
                throw new ArgumentException("de gewenste datum kan niet in het verleden zijn");
            }


            if (BerekenWeek(date) == BerekenWeek(DateTime.Today))
            {

                //DateTime.ParseExact(DateTime.Today.ToString().Substring(0, 10), "dd/MM/yyyy", null)
                //   .ToString("MM/dd/yyyy");
                // returnt datum van volgende week
                if (date.DayOfWeek >= DayOfWeek.Monday && date.DayOfWeek <= DayOfWeek.Friday ||
                    (date.DayOfWeek == DayOfWeek.Friday && date.Hour <= 17))
                {
                    int daysUntilMonday = (((int)DayOfWeek.Monday - (int)date.DayOfWeek + 7) % 7);
                    return date.AddDays(daysUntilMonday).AddHours(8);
                }
                else
                {
                    // returnt datum van volgende volgende week (indien na vrijdag 17h)
                    int daysUntilMonday = (((int)DayOfWeek.Monday - (int)date.DayOfWeek + 7) % 7 + 7);
                    return date.AddDays(daysUntilMonday).AddHours(8);
                }

                throw new ArgumentException("kan niet reserveren voor deze week, selecteer ten vroegste volgende week");

            }

            int daysAfterMonday = (int)DayOfWeek.Monday - (int)date.DayOfWeek;
            return date.AddDays(daysAfterMonday).AddHours(8);

        }


        public DateTime BerekenEindDatumReservatieWeek(DateTime datum)
        {
            return BerekenStartDatumReservatieWeek(datum).AddDays(4).AddHours(9);
        }

        public int BerekenWeek(DateTime datum)
        {

            var currentCulture = CultureInfo.CurrentCulture;
            var weekNo = currentCulture.Calendar.GetWeekOfYear(
                             //haalt jaar, maand en dag uit string en zet om in int
                             new DateTime(datum.Year, datum.Month, datum.Day),
                            currentCulture.DateTimeFormat.CalendarWeekRule,
                            currentCulture.DateTimeFormat.FirstDayOfWeek);

            // YYYY/MM/DD
            // MM/DD/YYYY
            return weekNo;
        }

    }
}