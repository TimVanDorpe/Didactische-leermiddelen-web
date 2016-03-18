using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using Groep9.NET.Helpers;

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




        public DateTime SetStartDatumReservatieWeek(DateTime date)
        {
            // als de gewenste datum al gepasseerd is
            if (date < DateTime.Today)
            {
                throw new ArgumentException("de gewenste datum kan niet in het verleden zijn");
            }

            return Helper.BerekenStartDatumReservatieWeek(date);

            /*
            if (BerekenWeek(date) == BerekenWeek(DateTime.Today))
            {

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
            */
        }


        public DateTime SetEindDatumReservatieWeek(DateTime datum)
        {
            return Helper.BerekenEindDatumReservatieWeek(datum);
        }

        public int BerekenWeek(DateTime datum)
        {

            return Helper.BerekenWeek(datum);
        }

    }
}