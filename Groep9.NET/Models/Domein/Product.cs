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
        public int Prijs { get; set; }
        public int Aantal { get; set; }
        public bool Uitleenbaarheid { get; set; }
        public string Plaats { get; set; }
        public string Firma { get; set; }
        public string Doelgroep { get; set; }
        public string Leergebied { get; set; }

       

        public Product()
        {

        }
        public Product(int productnummer, string naam, string omschrijving)
        {
            this.ProductNummer = productnummer;
            this.Naam = naam;
            this.Omschrijving = omschrijving;
        
        
        }

    }
}