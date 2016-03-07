using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groep9.NET.Models.Domein
{
    public interface IGebruikerRepository
    {

        void Add(Gebruiker gebruiker);
        Gebruiker FindByEmail(String email);
        //void ReserveerProduct(Product p, DateTime start, DateTime eind, int aantal, Gebruiker gebruiker);
        void SaveChanges();

    }
}
