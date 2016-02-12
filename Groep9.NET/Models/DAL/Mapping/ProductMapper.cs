using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Groep9.NET.Models.DAL.Mapping
{
    public class ProductMapper : EntityTypeConfiguration<Product>
    {

        public ProductMapper()
        {

            //voorlopig!! moet nog verder uitgewerkt worden
            this.ToTable("Product");

            this.HasKey(p => p.ProductNummer);
            this.Property(p => p.Naam).IsRequired();
        }
    }
}