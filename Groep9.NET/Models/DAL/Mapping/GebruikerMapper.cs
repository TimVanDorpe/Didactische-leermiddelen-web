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
            Property(g => g.Email).IsRequired().HasMaxLength(200);
            HasMany(i => i.VerlangLijst).WithMany().Map(m =>
            {
                m.ToTable("Verlanglijst");
                m.MapLeftKey("GebruikerId");
                m.MapRightKey("ProductId");

            });

            //HasMany(i => i.ReservatieLijst).WithMany().Map(m => {
            //    m.ToTable("Reservaties");
            //    m.MapLeftKey("GebruikerId");
            //    m.MapRightKey("ProductId");

            //});
            // HasMany(t => t.VerlangLijst)
            //.WithOptional().WillCascadeOnDelete(false);
        }
    }
}