using Groep9.NET.Models.Domein;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Groep9.NET.Models.Domein
{
    public class Blokkering :ReservatieAbstr
    {
        
        
        public Blokkering()
        {
            
        }
        public Blokkering(Product product, int aantal, Gebruiker gebruiker, DateTime datum) : base(product, aantal, gebruiker, datum)
        {
            if (!(gebruiker is Personeelslid))
            {
                throw new ArgumentException("U moet ingelogd zijn als personeelslid om te reserveren.");
            }
            product.VoegReservatieOfBlokkeringToe(this);
                        
        }
      

    }
}