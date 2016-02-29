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
    public class Gebruiker
    {
        public int GebruikerId { get; set; }
        public string Email { get; set; }

       
        public string Rol { get; set; }
        
        public virtual ICollection<Product> VerlangLijst { get; set; }
        public virtual ICollection<Product> ReservatieLijst { get; set; } 
        public Gebruiker()
        {
            VerlangLijst = new List<Product>();
            ReservatieLijst = new List<Product>();
        }

        public void VoegProductAanVerlanglijstToe(Product p)
        {

            VerlangLijst.Add(p);
            
        }

        public void verwijderProductUitVerlanglijst(Product p)
        {
            VerlangLijst.Remove(p);
        }

    }
}