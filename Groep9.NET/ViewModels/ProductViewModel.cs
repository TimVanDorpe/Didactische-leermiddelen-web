using Groep9.NET.Models.Domein;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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

        [Display(Name = "Foto")]
        public string Foto { get; private set; }

        [DataType(DataType.MultilineText)]
        public string Omschrijving { get; private set; }

        [DisplayName("Beschikbaar")]
        public int Aantal { get; private set; }
        public double Prijs { get; private set; }
        public string Firma { get; private set; }
       // public Doelgroep Doelgroep { get; private set; }
        public string[] Leergebied { get; private set; }

        public string[] Doelgroep { get; private set; }
        public ProductViewModel(Product p)
        {

            //Van het materiaal toon je de foto, de naam, omschrijving, 
            //aantalInCatalogus, artikelNr (van de firma), prijs,
            //firma, doelgroepen, leergebieden

            Foto = p.Foto;
            Naam = p.Naam;
            Omschrijving = p.Omschrijving;
            Aantal = p.Aantal;
            ProductId = p.ProductId;
            Prijs = p.Prijs;
            Firma = p.Firma;
            Doelgroep = p.Doelgroepen.Select(i => i.Naam).OrderBy(i => i).ToArray();
            Leergebied = p.Leergebieden.Select(i => i.Naam).OrderBy(i => i).ToArray();


        }
        public ProductViewModel()
        {

        }
    }
}