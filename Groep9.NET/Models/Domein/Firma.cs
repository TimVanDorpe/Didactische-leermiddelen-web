using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace Groep9.NET
{
    public class Firma
    {
        public int FirmaId { get; set; }
        [DisplayName("Naam firma")]
        public string Naam{ get; set;   }
        [DisplayName("Website firma")]
        public string FirmaUrl { get; set; }
        [DisplayName("Firma E-Mail")]
        public string Contactemail { get; set; }

        public Firma()
        {

        }

        public Firma(string naam, string firmaurl, string contactemail)
        {
            Naam = naam;
            FirmaUrl = firmaurl;
            Contactemail = contactemail;

        }


    }
}