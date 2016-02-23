using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Groep9.NET.Models.Domein
{
    public class Leergebied
    {

        public string Naam { get; set; }

        public int LeergebiedId { get; set; }

        public Leergebied(string naam)
        {
            Naam = naam;
        }
    }
}