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

        public override void VoegBlokkeringToe(Blokkering b)
        {

            BlokkeringLijst.Add(b);

        }

        public override void VerwijderBlokkering(Blokkering b)
        {
            BlokkeringLijst.Remove(b);
        }


    }
}
