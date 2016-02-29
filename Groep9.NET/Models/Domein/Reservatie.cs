using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Groep9.NET.Models.Domein {
    public class Reservatie {
        public Reservatie()
        {
           
        }

        public DateTime StartDatum { get; set; }
        public DateTime EindDatum { get; set; }
        public ICollection<Product> ProductenLijst { get; set; }


        public void Reserveer(Product product, DateTime start, DateTime eind, int aantal)
        {
            product.Aantal -= aantal;
            StartDatum = start;
            EindDatum = eind;
        }


    }
}