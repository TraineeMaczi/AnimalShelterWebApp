using Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Configuration
{
    public class ResidentConfiguration:EntityTypeConfiguration<Resident>
    {
        public ResidentConfiguration()
        {
            Property(x => x.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Name).HasMaxLength(50);
            Property(x => x.Type).HasMaxLength(50);
            Property(x => x.From).HasMaxLength(10);
            Property(x => x.To).HasMaxLength(10);
            Property(x => x.OwnerEmail).HasMaxLength(50);
            Property(x => x.Desc).HasMaxLength(1000);
        }
    }
}
