using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Linq;
using Groep9.NET.Models.Domein;

namespace Groep9.NET
{
    public class Verlanglijst
    {
        public Gebruiker Gebruiker
        { get; set; }
        private IList<Product> producten = new List<Product>();

        public virtual IEnumerable<Product> Producten
        {
            get { return producten.AsEnumerable(); } }

        public void AddProduct(Product product)
        {
            producten.Add(product);
        }

       

        public void RemoveProduct(Product product)
        {
            producten.Remove(product);
        }
    }
}