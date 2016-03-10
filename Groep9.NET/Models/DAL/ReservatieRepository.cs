using Groep9.NET.Models.Domein;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Groep9.NET.Models.DAL
{
    public class ReservatieRepository : IReservatieRepository
    {
        private Context context;
        private DbSet<Reservatie> reservaties;

        public ReservatieRepository(Context context)
        {
            this.context = context;
            reservaties = context.Reservaties;
        }

        public IQueryable<Reservatie> VindAlleReservaties()
        {
            return reservaties;
        }

        public void AddReservatie(Reservatie reservatie)
        {
            reservaties.Add(reservatie);
        }
        public void RemoveReservatie(Reservatie reservatie)
        {
            reservaties.Remove(reservatie);

        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

    }
}