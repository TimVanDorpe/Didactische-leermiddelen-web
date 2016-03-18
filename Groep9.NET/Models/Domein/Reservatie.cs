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
            StartDatum = SetStartDatumReservatieWeek(datum);
            EindDatum = SetEindDatumReservatieWeek(datum);
            product.VoegReservatieToe(this);
            
        }

  
    }
}