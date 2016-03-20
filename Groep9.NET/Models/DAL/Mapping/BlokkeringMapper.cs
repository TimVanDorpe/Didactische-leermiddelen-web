using Groep9.NET.Models.Domein;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Groep9.NET.Models.DAL.Mapping
{
    public class BlokkeringMapper: EntityTypeConfiguration<Blokkering>
    {
        public BlokkeringMapper()
        {
            ToTable("Blokkering");
            HasKey(p => p.Bl);
            Property(t => t.StartDatum).IsRequired();
            Property(t => t.EindDatum).IsRequired();

            HasMany(i => i.VerlangLijst).WithMany().Map(m =>
            {
                m.ToTable("Verlanglijst");
                m.MapLeftKey("GebruikerId");
                m.MapRightKey("ProductId");

            });


            HasRequired(r => r.Product).WithMany().Map(m => m.MapKey("ProductId")).WillCascadeOnDelete(false);
            HasRequired(r => r.Gebruiker).WithMany().Map(m => m.MapKey("GebruikerId")).WillCascadeOnDelete(false);
        }
    }
}
