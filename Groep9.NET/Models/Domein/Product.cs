﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Diagnostics;
using Groep9.NET.Models.Domein;
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

       

        [DisplayName("Beschikbaar")]
        public int Aantal { get; set; } // totaal in catalogus

        public bool Uitleenbaarheid { get; set; }

        public virtual ICollection<Doelgroep> Doelgroepen { get; set; }
        public virtual ICollection<Leergebied> Leergebieden { get; set; }
        public virtual ICollection<Reservatie> Reservaties { get; set; }

        public virtual ICollection<Blokkering> Blokkeringen { get; set; }

        public String Plaats { get; set; }


        public virtual Firma Firma { get; set; }

        public Product() {
            Doelgroepen = new List<Doelgroep>();
            Leergebieden = new List<Leergebied>();
            Reservaties = new List<Reservatie>();
            Blokkeringen = new List<Blokkering>();
        }

   
        public Product(string foto, string naam, string omschrijving, double prijs, int aantal, bool uitleenbaarheid, string plaats, Firma firma, List<Doelgroep> doelgroepen, List<Leergebied> leergebieden)
           : this() { 
            foreach (var doel in doelgroepen) {
                Doelgroepen.Add(doel);
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
        

        


        }

        public int BerekenWeek(DateTime datum)
        {
           
            var currentCulture = CultureInfo.CurrentCulture;
            var weekNo = currentCulture.Calendar.GetWeekOfYear(
                             //haalt jaar, maand en dag uit string en zet om in int
                             new DateTime(datum.Year, datum.Month, datum.Day),
                            currentCulture.DateTimeFormat.CalendarWeekRule,
                            currentCulture.DateTimeFormat.FirstDayOfWeek);

            // YYYY/MM/DD
            // MM/DD/YYYY
            return weekNo;
        }
        
        public int BerekenAantalGereserveerdOpWeek(DateTime datum)
        {
            int aantalGereserveerd = 0;
            int weekReservatie = 0;
            if (BerekenWeek(datum) == BerekenWeek(DateTime.Today))
            {
                weekReservatie =  BerekenWeek(datum)+1;
            }
                 weekReservatie = BerekenWeek(datum);
            foreach (Reservatie r in Reservaties)
            {
                int weekProduct =
                    BerekenWeek(r.StartDatum);

                if (weekReservatie == weekProduct)
                {
                    aantalGereserveerd += r.Aantal;
                }
            }
            return aantalGereserveerd;

        }
        public int BerekenAantalGeblokkeerdOpWeek(DateTime datum)
        {
            int aantalGeblokkeerd = 0;
            int weekBlokkering = 0;
            if (BerekenWeek(datum) == BerekenWeek(DateTime.Today))
            {
                weekBlokkering = BerekenWeek(datum) + 1;
            }
            weekBlokkering = BerekenWeek(datum);
            foreach (Blokkering b in Blokkeringen)
            {
                int weekProduct =
                    BerekenWeek(b.StartDatum);

                if (weekBlokkering == weekProduct)
                {
                    aantalGeblokkeerd += b.Aantal;
                }
            }
            return aantalGeblokkeerd;

        }

        public void VoegReservatieToe(Reservatie r)
        {

            Reservaties.Add(r);

        }

        public void VerwijderReservatie(Reservatie r)
        {
            Reservaties.Remove(r);
        }
        public void VoegBlokkeringToe(Blokkering r)
        {

            Blokkeringen.Add(r);

        }

        public void VerwijderBlokkering(Blokkering r)
        {
            Blokkeringen.Remove(r);
        }


        public int BerekenAantalGereserveerd()//VALIDATIE OOK NIET VERGETEN
        {
            return Reservaties.Count;
        }


        public int BerekenAantalGeblokkeerd()
        {
            return Blokkeringen.Count;
        }

  




    }
}