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
            HasKey(p => p.ProductNummer);
            Property(t => t.Naam).IsRequired();
            //Property(t => t.Leergebied).IsRequired();
            Property(t => t.Omschrijving).IsRequired();
            /* Property(t => t.Plaats).IsRequired();
             Property(t => t.Prijs).IsRequired();
             Property(t => t.Uitleenbaarheid).IsRequired();*/

            //HasRequired(d => d.Doelgroepen).WithOptional().Map(m => m.MapKey("DoelgroepId"));
            //HasRequired(d => d.Leergebieden).WithOptional().Map(m => m.MapKey("LeergebiedId"));
            
        }

    }
}