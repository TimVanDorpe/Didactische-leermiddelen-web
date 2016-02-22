using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using Groep9.NET.Models.Domein;

namespace Groep9.NET {
    public class Product {
        public int ProductId { get; set; }
        public string Foto { get; set; }
        public string Naam { get; set; }
        public string Omschrijving { get; set; }
        public int ProductNummer { get; set; }
        public double Prijs { get; set; }
        public int Aantal { get; set; }
        public bool Uitleenbaarheid { get; set; }
        public Doelgroep Doelgroep { get; set; }
        public Leergebied Leergebied { get; set; }

        public String Plaats { get;

            set ;
        }

        public string Firma
        {
            get ;

            set ;
        }

        public Product()
        {

        }
        public Product(string foto, int productnummer, string naam, string omschrijving, double prijs, int aantal, bool uitleenbaarheid, string plaats, string firma, Doelgroep doelgroep, Leergebied leergebied)
        {
            this.Foto = foto;
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