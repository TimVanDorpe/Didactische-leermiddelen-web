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
            HasKey(p => p.GebruikerId);
            //Property(t => t.Naam).IsRequired();
            ////Property(t => t.Leergebied).IsRequired();
            //Property(t => t.Omschrijving).IsRequired();
            //HasOptional(p=>p.GebruikerId).WithMany(p => p.VerlangLijst);
           // HasOptional(t => t.VerlangLijst).WithMany().HasForeignKey(t => t.).WillCascadeOnDelete(true);
            HasMany(t => t.VerlangLijst).WithMany();
            // HasMany(t => t.VerlangLijst);
            //HasMany(i => i.VerlangLijst).WithMany(p => p.ProductId).Map(m => {
            //    m.ToTable("Verlanglijst");
            //    m.MapLeftKey("GebruikerId");
            //    m.MapRightKey("ProductId");

            //});

            HasMany(t => t.VerlangLijst)
           .WithOptional().WillCascadeOnDelete(false);
        }
    }
}