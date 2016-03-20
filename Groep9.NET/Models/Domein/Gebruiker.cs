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
        

        public virtual ICollection<ReservatieAbstr> ReservAbstrLijst { get; set; }

        protected Gebruiker()
        {
            VerlangLijst = new List<Product>();
            
            ReservAbstrLijst = new List<ReservatieAbstr>();
        }

        public void VoegProductAanVerlanglijstToe(Product p)
        {
            if (VerlangLijst.Contains(p))
            {
                VerwijderProductUitVerlanglijst(p);
            }
            else
            {
                VerlangLijst.Add(p);
            }
            
            
        }

        public void VerwijderProductUitVerlanglijst(Product p)
        {
            VerlangLijst.Remove(p);
        }
        public abstract void VoegReservatieAbstrToe(ReservatieAbstr r);


        public abstract void VerwijderReservatieAbstr(ReservatieAbstr r);
        


   

    }
}