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
        public string Naam { get; set; }
        [Required]
        public string Omschrijving { get; set; }
        public double Prijs { get; set; }

        [DisplayName("Beschikbaar")]
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

        /*
        public Product(string foto, string naam, string omschrijving, double prijs, int aantal, bool uitleenbaarheid, string plaats, string firma)
            : this() {
            Foto = foto;

            Naam = naam;
            Omschrijving = omschrijving;
            Prijs = prijs;
            Aantal = aantal;
            Uitleenbaarheid = uitleenbaarheid;
            Plaats = plaats;
            Firma = firma;
            AantalBeschikbaar = aantal;
        }
        */
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

            //Dit moet ook in de constuctor en dan in de init, even om iets te testen !!!
            this.AantalBeschikbaar = 20;
            this.AantalGereserveerd = 0;


        }




        public void Blokkeer(int aantal)
        {
            throw new NotSupportedException();
        }

       
    
    }
}