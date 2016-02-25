using Groep9.NET.Models.Domein;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Groep9.NET.Models.DAL
{
    public class LeergebiedRepository : ILeergebiedRepository
    {
        private Context context;
        private DbSet<Leergebied> Leergebieden;

        public LeergebiedRepository(Context context)
        {
            this.context = context;
            Leergebieden = context.Leergebieden;
        }

        public Leergebied FindById(int id)
        {
          return  Leergebieden.Find(id);
        }

        public IQueryable<Leergebied> VindAlleLeergebieden()
        {
            return Leergebieden;
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}