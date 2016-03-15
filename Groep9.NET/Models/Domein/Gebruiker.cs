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
        public int GebruikerId { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Product> VerlangLijst { get; set; }
        public virtual ICollection<Reservatie> ReservatieLijst { get; set; } 

      //  public virtual ICollection<Blokkade> BlokkadeLijst { get; set; }
        public Gebruiker()
        {
            VerlangLijst = new List<Product>();
            ReservatieLijst = new List<Reservatie>();
      //      BlokkadeLijst = new List<Blokkade>();
        }

        public void VoegProductAanVerlanglijstToe(Product p)
        {

            VerlangLijst.Add(p);
            
        }

        public void VerwijderProductUitVerlanglijst(Product p)
        {
            VerlangLijst.Remove(p);
        }
        public virtual void  VoegReservatieToe(Reservatie r)
        {

            ReservatieLijst.Add(r);

        }

        public virtual  void VerwijderReservatie(Reservatie r)
        {
            ReservatieLijst.Remove(r);
        }

    }
}