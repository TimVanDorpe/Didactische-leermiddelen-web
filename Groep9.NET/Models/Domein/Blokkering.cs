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
        public int BlokkeringId { get; set; }
     

       

        public virtual ICollection<Dag> Weekdagen { get; set; }


        public Blokkering(Product product, int aantal, Gebruiker gebruiker, DateTime datum): base()
        {
            Gebruiker = gebruiker;
            Product = product;
            Aantal = aantal;
            StartDatum = SetStartDatumReservatieWeek(datum);
            EindDatum = SetEindDatumReservatieWeek(datum);
            product.VoegBlokkeringToe(this);
            


        }

        public void addWeekdag(bool Maandag , bool Dinsdag, bool Woensdag, bool Donderdag, bool Vrijdag)
        {
            if (Maandag == true)
            { Dag Ma = new Dag("Maandag");
                Weekdagen.Add(Ma);
            }
            if (Dinsdag == true)
            { Dag Di = new Dag("Dinsdag");
                Weekdagen.Add(Di);
            }
            if (Woensdag == true)
            { Dag Wo = new Dag("Woensdag");
                Weekdagen.Add(Wo);
            }
            if (Donderdag == true)
            { Dag Do = new Dag("Donderdag");
                Weekdagen.Add(Do);
            }
            if (Vrijdag == true)
            { Dag Vr = new Dag("Vrijdag");
                Weekdagen.Add(Vr);
            }
           
        }

     

    }
}