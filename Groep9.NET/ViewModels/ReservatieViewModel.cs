﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Groep9.NET.Models.Domein;

namespace Groep9.NET.ViewModels
{   
        public class ReservatieViewModel
        {
            public DateTime StartDatum { get; set; }
            public DateTime EindDatum { get; set; }



          public Gebruiker Gebruiker { get; set; }
    

        public ReservatieViewModel(Product product, DateTime start, DateTime eind, int aantal)
            {
                product.Aantal -= aantal;
                StartDatum = start;
                EindDatum = eind;

            
            }
                
    } }