using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Groep9.NET.Models.Domein
{
    public class Doelgroep
    {
        private string naam;


        public string Naam
        {
            get { return naam; }
            set { naam = value; }
        }

        public int DoelgroepId
        {
            get; set;
        }

        public Doelgroep()
        {
            
        }
    }
}