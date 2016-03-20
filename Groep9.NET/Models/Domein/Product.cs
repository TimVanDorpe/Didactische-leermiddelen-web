using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Diagnostics;
using Groep9.NET.Models.Domein;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Groep9.NET.Helpers;

namespace Groep9.NET {
    public class Product
    {

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
        public virtual ICollection<ReservatieAbstr> ReservatiesAbstr { get; set; }

        //  public virtual ICollection<Blokkering> Blokkeringen { get; set; }

        public String Plaats { get; set; }


        public virtual Firma Firma { get; set; }

        public Product()
        {
            Doelgroepen = new List<Doelgroep>();
            Leergebieden = new List<Leergebied>();
            ReservatiesAbstr = new List<ReservatieAbstr>();
            // Blokkeringen = new List<Blokkering>();
        }


        public Product(string foto, string naam, string omschrijving, double prijs, int aantal, bool uitleenbaarheid,
            string plaats, Firma firma, List<Doelgroep> doelgroepen, List<Leergebied> leergebieden)
            : this()
        {
            foreach (var doel in doelgroepen)
            {
                Doelgroepen.Add(doel);
            }
            foreach (var leer in leergebieden)
            {

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


        public int BerekenAantalReservatiesOfBlokkeringenOpWeek(DateTime datum, string klasse)
        {
           
            int aantalReservaties = 0;
            int aantalBlokkeringen = 0;
            int weekReservatie = 0;
            if (Helper.BerekenWeek(datum) == Helper.BerekenWeek(DateTime.Today))
            {
                weekReservatie = Helper.BerekenWeek(datum) + 1;
            }
            weekReservatie = Helper.BerekenWeek(datum);

            foreach (ReservatieAbstr r in ReservatiesAbstr)
            {
                int weekProduct =
                    Helper.BerekenWeek(r.StartDatum);




                if (weekReservatie == weekProduct)
                {
                    if (r is Reservatie)
                    {
                        aantalReservaties += r.Aantal;
                    }
                    else if (r is Blokkering)
                    {
                        aantalBlokkeringen += r.Aantal;
                    }



                }
               

            }
            if (klasse.Equals("reservatie"))
            {
                return aantalReservaties;
            }
            else if (klasse.Equals("blokkering"))
            {
                return aantalBlokkeringen;
            }
            else
            {
                return 0;
            }
        }

     

        public void VoegReservatieOfBlokkeringToe(ReservatieAbstr r)
        {
            ReservatiesAbstr.Add(r);
        }

        public void VerwijderReservatieOfBlokkering(ReservatieAbstr r)
        {
            ReservatiesAbstr.Remove(r);
        }

    
  




    }
}