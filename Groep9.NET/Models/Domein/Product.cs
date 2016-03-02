using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Diagnostics;
using Groep9.NET.Models.Domein;
using System.Diagnostics;

namespace Groep9.NET {
    public class Product {
        public int ProductId { get; set; }
        public string Foto { get; set; }
        public string Naam { get; set; }
        public string Omschrijving { get; set; }

        public double Prijs { get; set; }
        [DisplayName("Beschikbaar")]


        public int Aantal { get; set; }

        public int AantalReserveerbaar { get; set; }

        public int AantalGeblokkeerd { get; set; }//enkel geblokkeerd
        public int AantalGereserveerd { get; set; }//enkel gereserveerd


        public bool Uitleenbaarheid { get; set; }

        public virtual ICollection<Doelgroep> Doelgroepen { get; set; }
        public virtual ICollection<Leergebied> Leergebieden { get; set; }

        public String Plaats { get; set; }


        public string Firma { get; set; }

        public Product() {
            Doelgroepen = new List<Doelgroep>();
            Leergebieden = new List<Leergebied>();
        }


        public Product(string foto, string naam, string omschrijving, double prijs, int aantal, bool uitleenbaarheid, string plaats, string firma)
            : this() {
            this.Foto = foto;

            this.Naam = naam;
            this.Omschrijving = omschrijving;
            this.Prijs = prijs;
            this.Aantal = aantal;
            this.Uitleenbaarheid = uitleenbaarheid;
            this.Plaats = plaats;
            this.Firma = firma;
            AantalReserveerbaar = aantal;
        }

        public Product(string foto, int productnummer, string naam, string omschrijving, double prijs, int aantal, bool uitleenbaarheid, string plaats, string firma, List<Doelgroep> doelgroepen, List<Leergebied> leergebieden)
           : this(foto, naam, omschrijving, prijs, aantal, uitleenbaarheid, plaats, firma) {

            foreach (var doel in doelgroepen) {

                Doelgroepen.Add(doel);
                // doel.RegistreerProduct(this);
            }
            foreach (var leer in leergebieden) {

                Leergebieden.Add(leer);
                leer.RegistreerLeergebied(this);
            }


        }


        public void Reserveer(int aantal)
        {

            if (aantal > AantalReserveerbaar)
            {
                throw new ArgumentException("Er zijn niet genoeg producten beschikbaar voor jouw gewenste hoeveelheid");
            }
            else {
                AantalReserveerbaar -= aantal;
                AantalGereserveerd += aantal;
            }
            // nog de week instellen, als week van reservatie verlopen is, AantalReserveerbaar weer optellen, en AantalGereserveerd weer aftrekken
            //bijhouden vanaf welke dag het uitgeleend ist , en tot welke dag. Als die laaste voorbij is, aantallen aanpassen

        }

        public void Blokkeer(int aantal)
        {
            throw new NotSupportedException();
        }

        public static DateTime BerekenReservatieWeek()
        {

            DateTime today = DateTime.Today;
            if (DateTime.Now.Day >= 1 && DateTime.Now.Day <= 5 || (DateTime.Now.Day == 5 && DateTime.Now.Hour <= 17))
            {
                int daysUntilMonday= (((int) DayOfWeek.Monday - (int) today.DayOfWeek+7 )%7);
                return today.AddDays(daysUntilMonday);
            }
            else
            {
                int daysUntilMonday = (((int)DayOfWeek.Monday - (int)today.DayOfWeek + 7) % 7 +7);
                return today.AddDays(daysUntilMonday+7);
            }

            

        }

    
    }
}