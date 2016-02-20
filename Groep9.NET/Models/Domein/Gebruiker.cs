using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Collections.Generic;
using System.Security.Claims;

namespace Groep9.NET {
    public abstract class Gebruiker : ClaimsPrincipal {
         public string GebruikersNummer { get; set; }
        public string Naam
        {
            get { return this.FindFirst(ClaimTypes.Name).Value; }
        }
        public string Country
        {
            get
            { return this.FindFirst(ClaimTypes.Country).Value; }
        }
        public string Email
        {
            get
            { return this.FindFirst(ClaimTypes.Email).Value; }
        }
        int GebruikersID { get; }
        ICollection<Product> VerlangLijst { get; set; }

        public abstract void voegProductAanVerlanglijstToe(Product p);

        public Gebruiker(ClaimsPrincipal principal)
            : base(principal) {
        }

    }
}