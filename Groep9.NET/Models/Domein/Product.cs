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
    
        public int Aantal { get; set; } // totaal in catalogus

        public int AantalBeschikbaar { get; set; } // enkel de beschikbare

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

            Naam = naam;
            Omschrijving = omschrijving;
            Prijs = prijs;
            Aantal = aantal;
            Uitleenbaarheid = uitleenbaarheid;
            Plaats = plaats;
            Firma = firma;
            AantalBeschikbaar = aantal;
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


        

        public void Blokkeer(int aantal)
        {
            throw new NotSupportedException();
        }

       
    
    }
}