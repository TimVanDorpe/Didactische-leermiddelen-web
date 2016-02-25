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


            ToTable("Gebruiker");
            //Properties
            HasKey(t => t.Email);
          


            //Relationships
            HasMany(t => t.VerlangLijst)
                .WithRequired()
                .Map(t => t.MapKey("Email"))
                .WillCascadeOnDelete(false);
        }
    }
         }               



