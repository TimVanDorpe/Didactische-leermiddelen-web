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

        public Personeelslid(): base() {      }

        public override void VoegReservatieAbstrToe(ReservatieAbstr r)
        {
            
            ReservAbstrLijst.Add(r);
        }

        public override void VerwijderReservatieAbstr(ReservatieAbstr r)
        {
            r.Product.Blokkeringen.Remove((Blokkering)r);
            ReservAbstrLijst.Remove(r);
        }


    }
}
