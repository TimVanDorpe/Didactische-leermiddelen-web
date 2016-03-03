﻿using Groep9.NET.Models.Domein;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Groep9.NET.Models.DAL.Mapping
{
    public class ReservatieMapper: EntityTypeConfiguration<Reservatie>
    {
        
            public ReservatieMapper()
            {
                ToTable("Reservatie");
                HasKey(p => p.ReservatieId);
                Property(t => t.StartDatum);
                Property(t => t.EindDatum);
               

            }

        
    }
}