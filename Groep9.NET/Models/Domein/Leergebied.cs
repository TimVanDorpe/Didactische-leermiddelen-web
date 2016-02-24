using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Groep9.NET.Models.Domein
{
    public class Leergebied
    {

        public string Naam { get; set; }

        public int LeergebiedId { get; set; }


        public virtual ICollection<Product> Producten { get; set; }

        public Leergebied()
        {
            Producten = new List<Product>();

        }

        public Leergebied(string naam)
            :this()
        {
            Naam = naam;
        }

        public void RegistreerLeergebied(Product product)
        {
            
            Producten.Add(product);
        }
    }
}