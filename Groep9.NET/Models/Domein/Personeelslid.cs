using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Collections.Generic;
using System.Security.Claims;
using Groep9.NET.Models.Domein;

namespace Groep9.NET {
    public class Personeelslid : Gebruiker {



        //public string GebruikersNummer { get; set; }
        //public String Naam { get; set; }
        //public String Voornaam { get; set; }
        public new string Email { get; set; }


        public new string Rol { get; set; }


        public new virtual ICollection<Product> VerlangLijst { get; set; }
        public Personeelslid() {
            VerlangLijst = new List<Product>();
        }
        public override void VoegProductAanVerlanglijstToe(Product p) {
            VerlangLijst.Add(p);
        }

        
        }
    }
