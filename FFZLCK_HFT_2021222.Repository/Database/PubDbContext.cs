using FFZLCK_HFT_2021222.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFZLCK_HFT_2021222.Repository.Database
{
    public class PubDbContext : DbContext
    {
        public DbSet<Available> Availables { get; set; }
        public DbSet<Drinks> Drinks { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Pub> Pubs { get; set; }
        public PubDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().UseInMemoryDatabase("pub");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Available>(available=> available
            .HasOne(avialble=>avialble.Pub)
            .WithMany(pub=>pub.Availables)
            .HasForeignKey(available => available.PubID)
            .OnDelete(DeleteBehavior.Restrict));

            modelBuilder.Entity<Available>(available => available
            .HasOne(available => available.Food)
            .WithMany(food => food.Availables)
            .HasForeignKey(available => available.FoodID)
            .OnDelete(DeleteBehavior.Restrict));

            modelBuilder.Entity<Available>(available=> available
            .HasOne(available=> available.Drinks)
            .WithMany(drinks=>drinks.Availables)
            .HasForeignKey(available => available.DrinkID)
            .OnDelete(DeleteBehavior.Restrict));

            modelBuilder.Entity<Pub>(pub=>pub
            .HasOne(pub=>pub.Available)
            .WithMany(available=>available.Drinks2)
            .HasForeignKey(drink=>drink.Food));
        }
    }
}
