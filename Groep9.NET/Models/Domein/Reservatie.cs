using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Groep9.NET.Models.Domein {
    public class Reservatie : ReservatieAbstr {

        public int ReservatieId { get;  set;}

        public Reservatie() {

        }

        public Reservatie(Product product, int aantal, Gebruiker gebruiker, DateTime datum) : base() {
            Gebruiker = gebruiker;
            Product = product;
            Aantal = aantal;
            StartDatum = BerekenStartDatumReservatieWeek(datum);
            EindDatum = BerekenEindDatumReservatieWeek(datum);
            product.VoegReservatieToe(this);

            //product.AantalBeschikbaar = product.AantalBeschikbaar - aantal;
            //product.AantalBeschikbaar = product.AantalGereserveerd + aantal;
            //p.AantalBeschikbaar -= hoeveelheid;
            //p.AantalGereserveerd += hoeveelheid;

        }

  
    }
}