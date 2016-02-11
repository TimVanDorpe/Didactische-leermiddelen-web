using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace Groep9.NET {
    public class Beheerder : Gebruikers {
        public int GebruikersID
        { get; set; }

        public string Naam { get; set; }

        public string Wachtwoord { get; set; }




        public void LogIn() {
            throw new NotImplementedException();
        }

        public void RolAanpassen() {
            throw new System.NotImplementedException();
        }
    }
}