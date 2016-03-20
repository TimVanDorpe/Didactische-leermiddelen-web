using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Groep9.NET.Models.DAL.Mapping
{
    public class FirmaMapper : EntityTypeConfiguration<Firma>
    {
        public FirmaMapper()
        {
            ToTable("Firma");
            Property(f => f.Naam).IsRequired().HasMaxLength(100);
            Property(f => f.Contactemail).IsRequired().HasMaxLength(100);
            Property(f => f.FirmaUrl).IsRequired().HasMaxLength(100);

            
        }
    }
}