using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model.Configuration;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class AppContext : DbContext
    {
        public DbSet<AboutShelterInfo> AboutShelterInfos { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Resident> Residents { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
        public AppContext() : base("AppConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new OrderConfiguration());
            modelBuilder.Configurations.Add(new ProductConfiguration());

            base.OnModelCreating(modelBuilder);
        }
        public static AppContext Create()
        {
            return new AppContext();
        }

    }
}
