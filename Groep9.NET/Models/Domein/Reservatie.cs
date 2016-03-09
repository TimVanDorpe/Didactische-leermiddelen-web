using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Groep9.NET.Models.Domein {
    public class Reservatie {
        public Reservatie()
        {
           
        }
        public int ReservatieId { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Startdatum van Reservatie")]
        public DateTime StartDatum { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Einddatum van Reservatie")]
        public DateTime EindDatum { get; set; }
        public Product Product { get; set; }
        public int Aantal { get; set; }

        public Gebruiker Gebruiker { get; set; }

        public Reservatie(Product product, int aantal, Gebruiker gebruiker)
        {
            this.Gebruiker = gebruiker;
            this.Product = product;
            this.Aantal = aantal;
            StartDatum = BerekenStartDatumReservatieWeek();
            EindDatum = BerekenEindDatumReservatieWeek();
            //product.AantalBeschikbaar = product.AantalBeschikbaar - aantal;
            //product.AantalBeschikbaar = product.AantalGereserveerd + aantal;
            //p.AantalBeschikbaar -= hoeveelheid;
            //p.AantalGereserveerd += hoeveelheid;
        }

        public DateTime BerekenStartDatumReservatieWeek(DateTime? d = null /* voor te testen*/)
        {

            DateTime today;

            if (d != null)
            {
                today = (DateTime) d;
            }
            else
            {
                today = DateTime.Today;
            }
            
            // returnt volgende week
            if (today.DayOfWeek >= DayOfWeek.Monday && today.DayOfWeek <= DayOfWeek.Friday || (today.DayOfWeek == DayOfWeek.Friday && today.Hour <= 17)) {
                int daysUntilMonday = (((int)DayOfWeek.Monday - (int)today.DayOfWeek + 7) % 7);
                return today.AddDays(daysUntilMonday).AddHours(8);
            }
            else {
                // returnt volgende volgende week (indien na vrijdag 17h)
                int daysUntilMonday = (((int)DayOfWeek.Monday - (int)today.DayOfWeek + 7) % 7 + 7);
                return today.AddDays(daysUntilMonday).AddHours(8);
            }
        }

        public DateTime BerekenEindDatumReservatieWeek(DateTime? d = null) {
            return BerekenStartDatumReservatieWeek(d).AddDays(4).AddHours(9);
        }



    }
}