using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using Groep9.NET.Helpers;

namespace Groep9.NET.Models.Domein
{
    public abstract class ReservatieAbstr
    {
        [DataType(DataType.Date)]
        [Display(Name = "Startdatum")]
        public DateTime StartDatum { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Einddatum")]
        public DateTime EindDatum { get; set; }
        public virtual Product Product { get; set; }
        public int Aantal { get; set; }
        public virtual Gebruiker Gebruiker { get; set; }

        public int ReservatieAbstrId { get; set; }

        protected ReservatieAbstr()
        {
            
        }
        protected ReservatieAbstr(Product product, int aantal, Gebruiker gebruiker, DateTime datum)
        {
            if (datum < DateTime.Today)
            {
                throw new ArgumentException("Je kan niet in het verleden reserveren");
            }
            if (aantal < 0)
            {
                throw new ArgumentException("Aantal moet positief zijn");
            }
            if (product.Aantal < (product.BerekenAantalReservatiesOfBlokkeringenOpWeek(datum, "reservatie") + Aantal))
            {
                throw new ArgumentException("Er zijn niet genoeg producten beschikbaar op de gewenste datum.");
            }

            Gebruiker = gebruiker;
            Product = product;
            Aantal = aantal;
            StartDatum = SetStartDatumReservatieWeek(datum);
            EindDatum = SetEindDatumReservatieWeek(datum);

        }


        public DateTime SetStartDatumReservatieWeek(DateTime date)
        {
            // als de gewenste datum al gepasseerd is
            if (date < DateTime.Today)
            {
                throw new ArgumentException("de gewenste datum kan niet in het verleden zijn");
            }

            return Helper.BerekenStartDatumReservatieWeek(date);
            
        }


        public DateTime SetEindDatumReservatieWeek(DateTime datum)
        {
            return Helper.BerekenEindDatumReservatieWeek(datum);
        }

        public int BerekenWeek(DateTime datum)
        {

            return Helper.BerekenWeek(datum);
        }

    }
}