using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;


namespace Groep9.NET.Models.DAL
{
    public class ProductMapper : EntityTypeConfiguration<Product>
    {
        public ProductMapper()
        {
            ToTable("Product");
            HasKey(p => p.ProductId);
            Property(t => t.Naam).IsRequired().HasMaxLength(100);            
            Property(t => t.Omschrijving).IsRequired().HasMaxLength(300);
            Property(t => t.Firma).IsRequired().HasMaxLength(100);
            Property(t => t.Plaats).IsRequired().HasMaxLength(100);
            Property(t => t.Foto).IsRequired().HasMaxLength(300);



        }

    }
}