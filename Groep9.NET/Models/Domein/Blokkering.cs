using Groep9.NET.Models.Domein;
using System;
using System.ComponentModel.DataAnnotations;

namespace Groep9.NET.Models.Domein
{
    public class Blokkering
    {

        public Blokkering()
        {

        }
        public int BlokkeringId { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Startdatum van Blokkering")]
        public DateTime StartDatum { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Einddatum van Blokkering")]
        public DateTime EindDatum { get; set; }
        public virtual Product Product { get; set; }
        public int Aantal { get; set; }

        public Gebruiker Gebruiker { get; set; }

        public Blokkering(Product product, int aantal, Gebruiker gebruiker, string datum)
        {
            Gebruiker = gebruiker;
            Product = product;
            Aantal = aantal;
            StartDatum = BerekenStartDatumReservatieWeek(datum);
            EindDatum = BerekenEindDatumReservatieWeek(datum);
            //product.AantalBeschikbaar = product.AantalBeschikbaar - aantal;
            //product.AantalBeschikbaar = product.AantalGereserveerd + aantal;
            //p.AantalBeschikbaar -= hoeveelheid;
            //p.AantalGereserveerd += hoeveelheid;

        }

        public DateTime BerekenStartDatumReservatieWeek(string datum, DateTime? d = null/* voor te testen*/)
        {
            DateTime date;

            if (d != null)
            {
                date = (DateTime)d;
            }
            else
            {
                date = new DateTime(Int32.Parse(datum.Substring(6, 4)), Int32.Parse(datum.Substring(0, 2)), Int32.Parse(datum.Substring(3, 2)));
            }

            // returnt datum van volgende week
            if (date.DayOfWeek >= DayOfWeek.Monday && date.DayOfWeek <= DayOfWeek.Friday || (date.DayOfWeek == DayOfWeek.Friday && date.Hour <= 17))
            {
                int daysUntilMonday = (((int)DayOfWeek.Monday - (int)date.DayOfWeek + 7) % 7);
                return date.AddDays(daysUntilMonday).AddHours(8);
            }
            else {
                // returnt datum van volgende volgende week (indien na vrijdag 17h)
                int daysUntilMonday = (((int)DayOfWeek.Monday - (int)date.DayOfWeek + 7) % 7 + 7);
                return date.AddDays(daysUntilMonday).AddHours(8);
            }
        }

        public DateTime BerekenEindDatumReservatieWeek(string datum, DateTime? d = null)
        {
            return BerekenStartDatumReservatieWeek(datum, d).AddDays(4).AddHours(9);
        }


    }
}