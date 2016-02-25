using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Groep9.NET.Models.Domein
{
    public interface IDoelgroepRepository
    {
        IQueryable<Doelgroep> VindAlleDoelgroepen();


        Doelgroep FindById(int id);
    }
}