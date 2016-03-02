using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Groep9.NET.Models.Domein {
    public class Reservatie {
        public Reservatie(Product p, DateTime start, DateTime eind, int aantal )
        {
            Product = p;
            StartDatum = start;
            EindDatum = eind;
            Aantal = aantal;
        }
        
        public int ReservatieId { get; set; }
        public DateTime StartDatum { get; set; }
        public DateTime EindDatum { get; set; }
        public Product Product { get; set; }
        public int Aantal { get; set; }



    }
}