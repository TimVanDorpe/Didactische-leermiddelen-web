using Groep9.NET.Models.Domein;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Groep9.NET.Models.DAL.Mapping
{
    public class DoelgroepMapper : EntityTypeConfiguration<Doelgroep>
    {
        public DoelgroepMapper()
        {
            ToTable("Doelgroep");
            HasKey(p => p.DoelgroepId);
            Property(t => t.Naam).IsRequired().HasMaxLength(100);

            HasMany(i => i.Producten).WithMany(p => p.Doelgroepen).Map(m => {
                m.ToTable("ProductenDoelgroep");
                m.MapLeftKey("DoelgroepId");
                m.MapRightKey("ProductId");
            });
        }
    }
}