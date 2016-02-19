using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Collections.Generic;
using System.Security.Claims;

namespace Groep9.NET {
    public class Docent : Gebruiker {
        public int GebruikersID { get; set; }

        
        public virtual ICollection<Product> VerlangLijst { get; set; }
       

        public Docent(ClaimsPrincipal principal)
            :base(principal)
        {
            VerlangLijst = new List<Product>();

        }

        public string Wachtwoord { get; set; }

        

        public override void voegProductAanVerlanglijstToe(Product p)
        {
            VerlangLijst.Add(p);
        }
                
    }
}