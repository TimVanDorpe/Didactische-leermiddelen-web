using Groep9.NET.Models.Domein;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Groep9.NET.Models.DAL.Mapping
{
    public class LeergebiedMapper : EntityTypeConfiguration<Leergebied>
    {
        public LeergebiedMapper()
        {
            ToTable("Leergebied");
            HasKey(p => p.LeergebiedId);
            Property(t => t.Naam).IsRequired().HasMaxLength(100);

            HasMany(i => i.Producten).WithMany(p => p.Leergebieden).Map(m => {
                m.ToTable("ProductLeergebied");
                m.MapLeftKey("LeergebiedId");
                m.MapRightKey("ProductId");
               
            });
        }
    }
}