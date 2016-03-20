using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Groep9.NET.Models.Domein {
    public class Reservatie : ReservatieAbstr {

        public Reservatie()
        {

        }

        
        public Reservatie(Product product, int aantal, Gebruiker gebruiker, DateTime datum) : base(product, aantal, gebruiker, datum)
        {
            if (!(gebruiker is Student))
            {
                throw new ArgumentException("U moet ingelogd zijn als student om te reserveren.");
            }
            product.VoegReservatieOfBlokkeringToe(this);
            
        }

        
    }
}