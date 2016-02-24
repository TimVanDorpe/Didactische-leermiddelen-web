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

            //HasMany(t => t.Products).WithRequired(t => t.Category).Map(m => m.MapKey("CategoryId")).WillCascadeOnDelete(false);
        }
    }
}