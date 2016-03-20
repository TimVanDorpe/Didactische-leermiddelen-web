using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Groep9.NET.Models.Domein;

namespace Groep9.NET.Models.DAL.Mapping
{
    public class DagMapper : EntityTypeConfiguration<Dag>
    {
        public DagMapper()
        {
            ToTable("Dag");
            HasKey(p => p.DagId);
            Property(f => f.Naam).IsRequired().HasMaxLength(100);
           
        }
    }
}