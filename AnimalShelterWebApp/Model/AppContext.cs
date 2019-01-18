using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model.Configuration;
using Model.Entities;

using System.Data.Entity;


namespace Model
{
    public class AppContext : DbContext
    {
        public DbSet<AboutShelterInfo> AboutShelterInfos { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Resident> Residents { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
        public AppContext() : base("AnimalShelterConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AboutShelterConfiguration());
            modelBuilder.Configurations.Add(new EventConfiguration());
            modelBuilder.Configurations.Add(new ItemConfiguration());
            modelBuilder.Configurations.Add(new ResidentConfiguration());
            modelBuilder.Configurations.Add(new SubscriberConfiguration());
            base.OnModelCreating(modelBuilder);
        }
        public static AppContext Create()
        {
            return new AppContext();
        }

    }
}
