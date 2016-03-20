using Groep9.NET.Models.Domein;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Groep9.NET.Models.Domein
{
    public class Blokkering :ReservatieAbstr
    {

        
        
       
     

       

        public virtual ICollection<Dag> Weekdagen { get; set; }

        public Blokkering()
        {
            
        }
        public Blokkering(Product product, int aantal, Gebruiker gebruiker, DateTime datum) : base(product, aantal, gebruiker, datum)
        {
            if (!(gebruiker is Personeelslid))
            {
                throw new ArgumentException("U moet ingelogd zijn als personeelslid om te reserveren.");
            }
            product.VerwijderReservatieOfBlokkering(this);
            


        }

        public void AddWeekdag(bool maandag , bool dinsdag, bool woensdag, bool donderdag, bool vrijdag)
        {
            if (maandag == true)
            { Dag Ma = new Dag("maandag");
                Weekdagen.Add(Ma);
            }
            if (dinsdag == true)
            { Dag Di = new Dag("dinsdag");
                Weekdagen.Add(Di);
            }
            if (woensdag == true)
            { Dag Wo = new Dag("woensdag");
                Weekdagen.Add(Wo);
            }
            if (donderdag == true)
            { Dag Do = new Dag("donderdag");
                Weekdagen.Add(Do);
            }
            if (vrijdag == true)
            { Dag Vr = new Dag("vrijdag");
                Weekdagen.Add(Vr);
            }
           
        }

     

    }
}