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
        private DbSet<Product> Producten;

        public ProductRepository(Context context)
        {
            this.context = context;
            Producten = context.Producten;
        }

        public IQueryable<Product> VindAlleProducten()
        {
            return Producten ;
        }

        public void Add(Product product)
        {
            Producten.Add(product) ;
        }

        public void Delete(Product product)
        {
            Producten.Remove(product) ;
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public IQueryable<Product> VindAlleDoelgroepen()
        {
            return context.Producten;
        }



        public Product FindByProductNummer(int productnummer)
        {
            return Producten.Find(productnummer);
        }

        public List<Product> GeavanceerdZoeken(string Trefwoord, string Doelgroep, string Leergebied)
        {
            throw new System.NotImplementedException();
        }

       
    }
}