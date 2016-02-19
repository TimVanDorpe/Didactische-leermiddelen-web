using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groep9.NET.Models.Domein
{
    interface IGebruikerRepository
    {
        IQueryable<Gebruiker> VindAlleGebruikers();

        void Add(Gebruiker gebruiker);
        void Delete(Gebruiker gebruiker);
        Gebruiker FindByGebruikerID(String gebruikersNummer);
        void SaveChanges();

    }
}
