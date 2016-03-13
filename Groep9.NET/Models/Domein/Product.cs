using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Diagnostics;
using Groep9.NET.Models.Domein;
using System.Diagnostics;
using System.ComponentModel.DataAnnotations;

namespace Groep9.NET {
    public class Product {

        [Required]
        public int ProductId { get; set; }
        [Required]
        public string Foto { get; set; }
        [Required]
        [DisplayName("Naam product")]
        public string Naam { get; set; }
        [Required]
        public string Omschrijving { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}")]
        public double Prijs { get; set; }

        public int AantalBeschikbaar { get; set; } // enkel de beschikbare

        public int AantalGeblokkeerd { get; set; }//enkel geblokkeerd
        public int AantalGereserveerd { get; set; }//enkel gereserveerd

        [DisplayName("Beschikbaar")]
        public int Aantal { get; set; } // totaal in catalogus

        public bool Uitleenbaarheid { get; set; }

        public virtual ICollection<Doelgroep> Doelgroepen { get; set; }
        public virtual ICollection<Leergebied> Leergebieden { get; set; }

        public String Plaats { get; set; }


        public string Firma { get; set; }

        public Product() {
            Doelgroepen = new List<Doelgroep>();
            Leergebieden = new List<Leergebied>();
        }

   
        public Product(string foto, string naam, string omschrijving, double prijs, int aantal, bool uitleenbaarheid, string plaats, string firma, List<Doelgroep> doelgroepen, List<Leergebied> leergebieden)
           : this() { 
            foreach (var doel in doelgroepen) {
                Doelgroepen.Add(doel);
                // doel.RegistreerProduct(this);
            }
            foreach (var leer in leergebieden) {

                Leergebieden.Add(leer);
                leer.RegistreerLeergebied(this);
            }

            Foto = foto;
            Naam = naam;
            Omschrijving = omschrijving;
            Prijs = prijs;
            Aantal = aantal;
            Uitleenbaarheid = uitleenbaarheid;
            Plaats = plaats;
            Firma = firma;
            AantalBeschikbaar = aantal;
            AantalGeblokkeerd = 0;
            AantalGereserveerd = 0;

            //Dit moet ook in de constuctor en dan in de init, even om iets te testen !!!
        


        }

        public DateTime BerekenStartDatumReservatieWeek(DateTime? d = null /* voor te testen*/)
        {

            DateTime today;

            if (d != null)
            {
                today = (DateTime)d;
            }
            else
            {
                today = DateTime.Today;
            }

            // returnt volgende week
            if (today.DayOfWeek >= DayOfWeek.Monday && today.DayOfWeek <= DayOfWeek.Friday || (today.DayOfWeek == DayOfWeek.Friday && today.Hour <= 17))
            {
                int daysUntilMonday = (((int)DayOfWeek.Monday - (int)today.DayOfWeek + 7) % 7);
                return today.AddDays(daysUntilMonday).AddHours(8);
            }
            else {
                // returnt volgende volgende week (indien na vrijdag 17h)
                int daysUntilMonday = (((int)DayOfWeek.Monday - (int)today.DayOfWeek + 7) % 7 + 7);
                return today.AddDays(daysUntilMonday).AddHours(8);
            }
        }




        public int BerekenAantalGereserveerd(ICollection<Reservatie> reservaties)//VALIDATIE OOK NIET VERGETEN
        {
            throw new NotImplementedException();
        }


        public int BerekenAantalGeblokkeerd()
        {
            throw new NotImplementedException();
        }

        public int BerekenAantalBeschikbaar()
        {
        throw new NotImplementedException();
        }






    }
}