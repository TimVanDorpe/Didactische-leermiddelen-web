using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Groep9.NET.Models.Domein
{
    public abstract class Gebruiker
    {

        //public int GebruikersNummer { get; set; }
        //public string Naam { get; set; }
        //public string Voornaam { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; }




        //public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Gebruiker> manager) {
        //    // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
        //    var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
        //    // Add custom user claims here
        //    return userIdentity;
        //}

        public  ICollection<Product> VerlangLijst { get; set; }

        public abstract void VoegProductAanVerlanglijstToe(Product p);


       

        /*
        public Gebruiker(ClaimsPrincipal principal)
            : base(principal) {
        }
        */



    }
}