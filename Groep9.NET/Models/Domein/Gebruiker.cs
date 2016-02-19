using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace Groep9.NET {
    public interface Gebruiker {
        string Naam { get; set; }
        int GebruikersID { get; }

    }
}