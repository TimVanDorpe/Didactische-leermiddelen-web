using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Groep9.NET.Models.Domein
{
    public class Doelgroep
    {
        


        public string Naam
        {
            get; set;
        }

        public int DoelgroepId
        {
            get; set;
        }

       public virtual ICollection<Product> Producten { get; set; }

        public Doelgroep()
        {
            Producten = new List<Product>();
        }

        public Doelgroep(string naam)
            :this()
        {
            Naam = naam;   
        }


        public void RegistreerProduct(Product product)
        {
           
            Producten.Add(product);
        }
    }
}