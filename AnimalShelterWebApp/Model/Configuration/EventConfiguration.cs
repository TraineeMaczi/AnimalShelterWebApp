﻿using Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Configuration
{
   public class EventConfiguration: EntityTypeConfiguration<Event>
    {
        public EventConfiguration()
        {
            Property(x => x.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Name).HasMaxLength(50);
            Property(x => x.Date).HasMaxLength(10);
            Property(x => x.Time).HasMaxLength(50);
            Property(x => x.About).HasMaxLength(100);
        }
    }
}
