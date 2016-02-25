using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Groep9.NET.Models.Domein;

namespace Groep9.NET.Models.DAL.Mapping
{
    public class GebruikerMapper : EntityTypeConfiguration<Gebruiker>
    {
        public GebruikerMapper()
        {
            ToTable("Product");
            //HasKey(p => p.GebruikerId);
            //Property(t => t.Naam).IsRequired();
            ////Property(t => t.Leergebied).IsRequired();
            //Property(t => t.Omschrijving).IsRequired();
        }
    }
}