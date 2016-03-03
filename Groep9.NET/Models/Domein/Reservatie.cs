﻿using System;
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
        public ICollection<Product> VerlangLijst { get; set; }
        public int aantal { get; set; }


        public Reservatie(Product product, DateTime start, DateTime eind, int aantal)
        {
            product.Aantal -= aantal;
            StartDatum = start;
            EindDatum = eind;
        }


    }
}