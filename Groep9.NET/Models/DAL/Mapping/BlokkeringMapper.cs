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
            HasKey(p => p.BlokkeringId);
            Property(t => t.StartDatum).IsRequired();
            Property(t => t.EindDatum).IsRequired();

            //HasRequired(i => i.Product).WithMany().HasForeignKey(p=>p.Product).WillCascadeOnDelete(false));


            HasRequired(r => r.Product).WithMany().Map(m => m.MapKey("ProductId")).WillCascadeOnDelete(false);

            HasRequired(r => r.Gebruiker).WithMany().Map(m => m.MapKey("GebruikerId")).WillCascadeOnDelete(false);
        }
    }
    }
