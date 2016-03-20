using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Groep9.NET.Models.Domein;

namespace Groep9.NET.Models.DAL.Mapping
{
    public class ReservatieAbstrMapper : EntityTypeConfiguration<ReservatieAbstr>
    {
        public ReservatieAbstrMapper()
        {
            ToTable("ReservatieBlokering");
            HasKey(p => p.ReservatieAbstrId);

            HasMany(i => i.Weekdagen).WithMany().Map(m =>
            {
                m.ToTable("Weekdagen");
                m.MapLeftKey("ReservatieAbstrId");
                m.MapRightKey("DagId");

            });
            //HasMany(r => r.Weekdagen).WithRequired().Map(m => m.MapKey("ProductId")).WillCascadeOnDelete(false);
            HasRequired(r => r.Product).WithMany().Map(m => m.MapKey("ProductId")).WillCascadeOnDelete(false);
            HasRequired(r => r.Gebruiker).WithMany().Map(m => m.MapKey("GebruikerId")).WillCascadeOnDelete(false);
        }
    }
}