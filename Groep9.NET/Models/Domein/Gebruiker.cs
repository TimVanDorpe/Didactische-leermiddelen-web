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
    public abstract class Gebruiker {



        public virtual int GebruikerId { get; set; }
        public virtual string Email { get; set; }
        public virtual string Rol { get; set; }


        public ICollection<Product> VerlangLijst { get; set; }
        public virtual ICollection<Reservatie> ReservatieLijst { get; set; } 
        public Gebruiker()
        {
            VerlangLijst = new List<Product>();
            //ReservatieLijst = new List<Product>();



        }

        public virtual void VoegProductAanVerlanglijstToe(Product p)
        {

            VerlangLijst.Add(p);
            
        }
        
    }
}