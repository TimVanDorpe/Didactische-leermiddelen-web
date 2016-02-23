using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Groep9.NET.Models.Domein
{
    public class Doelgroep
    {
        


        public string Naam
        {
            get; set;
        }

        public int DoelgroepId
        {
            get; set;
        }

        public Doelgroep(string naam)
        {
            Naam = naam;   
        }
    }
}