using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Collections.Generic;
using Groep9.NET.Models.DAL;
using Groep9.NET.Models.Domein;
using System.Data.Entity;
using System.Linq;

namespace Groep9.NET
{
    public class ProductRepository : IProductRepository
    {

        private Context context;
        private System.Data.Entity.DbSet<Product> producten;

        public ProductRepository(Context context)
        {
            this.context = context;
            producten = context.producten;
        }

        public IQueryable<Product> VindAlleProducten()
        {
            return producten;
        }

        public void Add(Product product)
        {
            producten.Add(product);
        }

        public void Delete(Product product)
        {
            producten.Remove(product);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
              
      

        public Product Zoeken(string trefwoord)
        {

            return producten.Find(trefwoord);

        }

        public List<Product> GeavanceerdZoeken(string Trefwoord, string Doelgroep, string Leergebied)
        {
            throw new System.NotImplementedException();
        }

       
    }
}