using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Compilation;

namespace Groep9.NET.ViewModels {
   

    public class ProductViewModel
    {
        [Required]
        public int ProductId { get; private set; }

        [Required]
        public string Naam { get; private set; }
        public string Foto { get; private set; }

        [DataType(DataType.MultilineText)]
        public string Omschrijving { get; private set; }
        public int Aantal { get; private set; }
        public double Prijs { get; private set; }
        public string Firma { get; private set; }
        public string Doelgroep { get; private set; }
        public string Leergebied { get; private set; }
        public ProductViewModel(Product p)
        {

            //Van het materiaal toon je de foto, de naam, omschrijving, 
            //aantalInCatalogus, artikelNr (van de firma), prijs,
            //firma, doelgroepen, leergebieden

            Foto = p.FotoURL;
            Naam = p.Naam;
            Omschrijving = p.Omschrijving;
            Aantal = p.Aantal;
            ProductId = p.ProductNummer;
            Prijs = p.Prijs;
            Firma = p.Firma;
            Doelgroep = p.Doelgroep;
            Leergebied = p.Leergebied;



        }
        public ProductViewModel()
        {

        }
    }
}