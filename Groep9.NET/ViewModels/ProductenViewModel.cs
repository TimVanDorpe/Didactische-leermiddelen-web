﻿using Groep9.NET.Models.Domein;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Compilation;

namespace Groep9.NET.ViewModels {
   

    public class ProductenViewModel
    {
        public IEnumerable<ProductViewModel> Producten { get; set; }
        
        
        public ProductenViewModel()
        {
        }
       
    }

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

        public int Aantal { get; set; } // totaal in catalogus
        [Display(Name = "Geblokkeerd")]
        //public int AantalBeschikbaar { get; set; } // enkel de beschikbare

        public int AantalGeblokkeerd { get; set; }//enkel geblokkeerd
        [Display(Name = "Gereserveerd")]
        public int AantalGereserveerd { get; set; }//enkel gereserveerd
        public virtual ICollection<Reservatie> Reservaties { get; set; }

        public virtual ICollection<Blokkering> Blokkeringen { get; set; }


        public double Prijs { get; private set; }
        public string FirmaNaam { get; private set; }
        public string FirmaUrl { get; private set; }
        public string FirmaMail { get; private set; }
        // public Doelgroep Doelgroep { get; private set; }
        public string[] Leergebied { get; private set; }

        public string[] Doelgroep { get; private set; }
        public string Plaats { get; set; }
        public Boolean InVerlanglijst { get; private set; }
        public Boolean Uitleenbaarheid { get; set; }
        [Display(Name ="Beschikbaar")]
        public int AantalBeschikbaar { get; set; }
        public ProductViewModel(Product p, Gebruiker g, int aantalGereserveerd, int aantalGeblokkeerd)
        {

            //Van het materiaal toon je de foto, de naam, omschrijving, 
            //aantalInCatalogus, artikelNr (van de firma), prijs,
            //firma, doelgroepen, leergebieden
            Uitleenbaarheid= p.Uitleenbaarheid;
            Plaats = p.Plaats;
            Foto = p.Foto;
            Naam = p.Naam;
            Omschrijving = p.Omschrijving;
            Aantal = p.Aantal;
            ProductId = p.ProductId;
            Prijs = p.Prijs;
            FirmaNaam = p.Firma.Naam;
            FirmaUrl = p.Firma.FirmaUrl;
            FirmaMail = p.Firma.Contactemail;
          
            Doelgroep = p.Doelgroepen.Select(i => i.Naam).OrderBy(i => i).ToArray();
            Leergebied = p.Leergebieden.Select(i => i.Naam).OrderBy(i => i).ToArray();
            InVerlanglijst = g.VerlangLijst.Contains(p);
            AantalBeschikbaar = p.Aantal - aantalGereserveerd- aantalGeblokkeerd;
            AantalGereserveerd = aantalGereserveerd;
            AantalGeblokkeerd = aantalGeblokkeerd;
        }
        public ProductViewModel(Product p, Gebruiker g)
        {

            //Van het materiaal toon je de foto, de naam, omschrijving, 
            //aantalInCatalogus, artikelNr (van de firma), prijs,
            //firma, doelgroepen, leergebieden
            Uitleenbaarheid = p.Uitleenbaarheid;
            Plaats = p.Plaats;
            Foto = p.Foto;
            Naam = p.Naam;
            Omschrijving = p.Omschrijving;
            Aantal = p.Aantal;
            ProductId = p.ProductId;
            Prijs = p.Prijs;
            FirmaNaam = p.Firma.Naam;
            FirmaUrl = p.Firma.FirmaUrl;
            FirmaMail = p.Firma.Contactemail;

            Doelgroep = p.Doelgroepen.Select(i => i.Naam).OrderBy(i => i).ToArray();
            Leergebied = p.Leergebieden.Select(i => i.Naam).OrderBy(i => i).ToArray();
            InVerlanglijst = g.VerlangLijst.Contains(p);
        }
    }
}