using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Collections.Generic;

namespace Groep9.NET {
    public interface Gebruiker {
        string Naam { get; set; }
        int GebruikersID { get; }

         ICollection<Product> VerlangLijst { get; set; }

        void voegProductAanVerlanglijstToe(Product p);
    }
}