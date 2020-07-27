using Microsoft.EntityFrameworkCore;
using NightSword.Entities.Entity;
using NightSword.Map.Mapping.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NightSword.DataAccess.Context
{
    //DbContext için ve Bizim Database bağlantılarımız için öncelikle Microsoft.EntityFrameworkCore.SqlServer indirilir.
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        //Bu katmanın dll'lerine "Map & Entities" katmanlarının dll'leri eklenir.
       
        public DbSet<Page> Pages { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryMap()); //Yaptıgımız Map işlemini burada Apply ediyoruz.
            modelBuilder.ApplyConfiguration(new PageMap());
            modelBuilder.ApplyConfiguration(new ProductMap());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
         
        }
    }
}
