using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace Groep9.NET {
    public class Product {
        public string FotoURL { get; set; }
        public string Naam { get; set; }
        public string Omschrijving { get; set; }
        public int ProductNummer { get; set; }
        public double Prijs { get; set; }
        public int Aantal { get; set; }
        public bool Uitleenbaarheid { get; set; }
        public string Plaats { get; set; }
        public string Firma { get; set; }
        public string Doelgroep { get; set; }
        public string Leergebied { get; set; }

       

        public Product()
        {

        }
        public Product(string FotoURL, int productnummer, string naam, string omschrijving, double prijs, int aantal, bool uitleenbaarheid, string plaats, string firma, string doelgroep, string leergebied)
        {
            this.ProductNummer = productnummer;
            this.Naam = naam;
            this.Omschrijving = omschrijving;
            this.Prijs = prijs;
            this.Aantal = aantal;
            this.Uitleenbaarheid = uitleenbaarheid;
            this.Plaats = plaats;
            this.Firma = firma;
            this.Doelgroep = doelgroep;
            this.Leergebied = leergebied;

        
        
        }

       

    }
}