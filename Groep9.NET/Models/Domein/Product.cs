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
using System.Globalization;

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
        public virtual ICollection<Reservatie> Reservaties { get; set; }

        public String Plaats { get; set; }


        public string Firma { get; set; }

        public Product() {
            Doelgroepen = new List<Doelgroep>();
            Leergebieden = new List<Leergebied>();
            Reservaties = new List<Reservatie>();
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

        public int BerekenWeek(string datum)
        {
           
            var currentCulture = CultureInfo.CurrentCulture;
            var weekNo = currentCulture.Calendar.GetWeekOfYear(
                            //haalt jaar, maand en dag uit string en zet om in int
                            new DateTime(Int32.Parse(datum.Substring(6, 4)), Int32.Parse(datum.Substring(0, 2)), Int32.Parse(datum.Substring(3, 2))),
                            currentCulture.DateTimeFormat.CalendarWeekRule,
                            currentCulture.DateTimeFormat.FirstDayOfWeek);

            // YYYY/MM/DD
            // MM/DD/YYYY
            return weekNo;
        }
        public int BerekenReservatiesPerWeek(string datum)
        {
            throw new NotImplementedException();
        }

        public void VoegReservatieToe(Reservatie r)
        {

            Reservaties.Add(r);

        }

        public void VerwijderReservatie(Reservatie r)
        {
            Reservaties.Remove(r);
        }


        public int BerekenAantalGereserveerd(List<Reservatie> reservaties)//VALIDATIE OOK NIET VERGETEN
        {
            int x = 0;
            
            for(int i = 0; i < reservaties.Count; i++)
                {
                if (this.ProductId == reservaties[i].Product.ProductId )
                x += reservaties[i].Aantal;

                    }
            return x;
        }


        public int BerekenAantalGeblokkeerd()
        {
            throw new NotImplementedException();
        }

        public int BerekenAantalBeschikbaar(List<Reservatie> reservaties, List<Product> verlanglijst)
        {
            int x = 0;


            //dus al u aantallen - u reservaties , eigenlijk hebde zelf u reservaties niet nodig denkik *nog niet zker*
            return x;
        }






    }
}