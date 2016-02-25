using Groep9.NET.Models.Domein;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Groep9.NET.Models.DAL
{
    public class DoelgroepRepository : IDoelgroepRepository
    {
        private Context context;
        private DbSet<Doelgroep> Doelgroepen;
        public DoelgroepRepository(Context context)
        {
            this.context = context;
            Doelgroepen = context.Doelgroepen;
        }

        public Doelgroep FindById(int id)
        {
            return Doelgroepen.Find(id);
               
          }

        public IQueryable<Doelgroep> VindAlleDoelgroepen()
        {
            return Doelgroepen;
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}