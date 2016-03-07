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
            return Producten;
        }



        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public Product FindByProductNummer(int productnummer)
        {
            return Producten.Find(productnummer);
        }

        public void ReserveerProduct(Product p, int hoeveelheid)
        {
            //Product p = FindByProductNummer(productId);

            //if (hoeveelheid > p.AantalBeschikbaar)
            //{
            //    throw new ArgumentException("Er zijn niet genoeg producten beschikbaar voor jouw gewenste hoeveelheid");
            //}

            //p.AantalBeschikbaar -= hoeveelheid;
            //p.AantalGereserveerd += hoeveelheid;

            //DateTime startDatum = BerekenStartDatumReservatieWeek();
            //DateTime eindDatum = BerekenStartDatumReservatieWeek().AddDays(4).AddHours(9);// van maandag 8u tot vrijdag 5u

            
            
            // vvv niet zeker of dit nog nodig is

            // nog de week instellen, als week van reservatie verlopen is, AantalReserveerbaar weer optellen, en AantalGereserveerd weer aftrekken
            //bijhouden vanaf welke dag het uitgeleend ist , en tot welke dag. Als die laaste voorbij is, aantallen aanpassen

        }

        public DateTime BerekenStartDatumReservatieWeek()
        {

            DateTime today = DateTime.Today;
            // returnt volgende week
            if (DateTime.Now.Day >= 1 && DateTime.Now.Day <= 5 || (DateTime.Now.Day == 5 && DateTime.Now.Hour <= 17))
            {
                int daysUntilMonday = (((int) DayOfWeek.Monday - (int) today.DayOfWeek + 7)%7);
                return today.AddDays(daysUntilMonday).AddHours(8);
            }
            else
            {
                // returnt volgende volgende week (indien na vrijdag 17h)
                int daysUntilMonday = (((int) DayOfWeek.Monday - (int) today.DayOfWeek + 7)%7 + 7);
                return today.AddDays(daysUntilMonday).AddHours(8);
            }
        }

        public DateTime BerekenEindDatumReservatieWeek()
        {
            return BerekenStartDatumReservatieWeek().AddDays(4).AddHours(9);
        }







    }
}