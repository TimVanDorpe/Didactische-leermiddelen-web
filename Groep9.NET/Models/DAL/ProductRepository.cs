using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Collections.Generic;
using Groep9.NET.Models.DAL;
using System.Data.Entity;
using System.Linq;

namespace Groep9.NET
{
    public class ProductRepository
    {

        private Context context;
        private System.Data.Entity.DbSet<Product> producten;

        public ProductRepository(Context context)
        {
            this.context = context;
            producten = context.producten;
        }

        public IQueryable<Product> VindtAlleProducten()
        {
            return producten;
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
              
      

        public Product Zoeken(string Trefwoord)
        {

            return producten.Find(Trefwoord);

        }

        public List<Product> GeavanceerdZoeken(string Trefwoord, string Doelgroep, string Leergebied)
        {
            throw new System.NotImplementedException();
        }
    }
}