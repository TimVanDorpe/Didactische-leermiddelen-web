using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Groep9.NET.Models.Domein {
    public class Reservatie {
        public Reservatie()
        {
           
        }
        public int ReservatieId { get; set; }
        public DateTime StartDatum { get; set; }
        public DateTime EindDatum { get; set; }
        public Product product { get; set; }
        public int aantal { get; set; }


        public Reservatie(Product product, int aantal)
        {
            this.product = product;
            this.aantal = aantal;
            StartDatum = BerekenStartDatumReservatieWeek();
            EindDatum = BerekenEindDatumReservatieWeek();
            //product.AantalBeschikbaar = product.AantalBeschikbaar - aantal;
            //product.AantalBeschikbaar = product.AantalGereserveerd + aantal;
            //p.AantalBeschikbaar -= hoeveelheid;
            //p.AantalGereserveerd += hoeveelheid;
        }

        public DateTime BerekenStartDatumReservatieWeek() {

            DateTime today = DateTime.Today;
            // returnt volgende week
            if (DateTime.Now.Day >= 1 && DateTime.Now.Day <= 5 || (DateTime.Now.Day == 5 && DateTime.Now.Hour <= 17)) {
                int daysUntilMonday = (((int)DayOfWeek.Monday - (int)today.DayOfWeek + 7) % 7);
                return today.AddDays(daysUntilMonday).AddHours(8);
            }
            else {
                // returnt volgende volgende week (indien na vrijdag 17h)
                int daysUntilMonday = (((int)DayOfWeek.Monday - (int)today.DayOfWeek + 7) % 7 + 7);
                return today.AddDays(daysUntilMonday).AddHours(8);
            }
        }

        public DateTime BerekenEindDatumReservatieWeek() {
            return BerekenStartDatumReservatieWeek().AddDays(4).AddHours(9);
        }



    }
}