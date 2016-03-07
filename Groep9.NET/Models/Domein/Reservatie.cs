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


        public Reservatie(Product product, DateTime start, DateTime eind, int aantal)
        {
            this.product = product;
            this.aantal = aantal;
            StartDatum = start;
            EindDatum = eind;
            //product.AantalBeschikbaar = product.AantalBeschikbaar - aantal;
            //product.AantalBeschikbaar = product.AantalGereserveerd + aantal;
            //p.AantalBeschikbaar -= hoeveelheid;
            //p.AantalGereserveerd += hoeveelheid;
        }


    }
}