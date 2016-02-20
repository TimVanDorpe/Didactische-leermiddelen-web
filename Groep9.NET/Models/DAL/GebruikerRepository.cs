using Groep9.NET.Models.Domein;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Groep9.NET.Models.DAL
{
    public class GebruikerRepository // :IGebruikerRepository
    {

        private Context context;
       // private DbSet<Gebruiker> gebruikers;

        public GebruikerRepository(Context context)
        {
            this.context = context;
            //gebruikers = context.Gebruikers;
        }



        //public void Add(Gebruiker gebruiker)
        //{
        //    gebruikers.Add(gebruiker);
        //}
        //public Gebruiker FindByEmail(string email)
        //{
        //    return gebruikers.FirstOrDefault(g => g.Email == email);
        //}

        //public void Delete(Gebruiker gebruiker)
        //{
        //    gebruikers.Remove(gebruiker);
        //}

        //public Gebruiker FindByGebruikerID(String gebruikersNummer)
        //{
        //    return gebruikers.Find(gebruikersNummer);
        //}

        //public IQueryable<Gebruiker> VindAlleGebruikers()
        //{
        //    return gebruikers;
        //}
        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}