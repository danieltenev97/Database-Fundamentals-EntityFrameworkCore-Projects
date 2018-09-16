using AlbumDatabaseAndXmlExercise.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlbumDatabaseAndXmlExercise.Data
{
   public class AlbumDatabaseContext :DbContext
    {
        public AlbumDatabaseContext() { }

        public AlbumDatabaseContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<CategoryProducts> CategoryProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryProducts>().HasKey(x => new
            {
                x.ProductId,
                x.CategoryId
            });
            modelBuilder.Entity<CategoryProducts>().HasOne(x => x.Categories)
                .WithMany(x => x.categoryProducts).HasForeignKey(x => x.CategoryId);
            modelBuilder.Entity<CategoryProducts>().HasOne(x => x.products)
                .WithMany(x => x.categoryProducts)
                .HasForeignKey(x => x.ProductId);
            modelBuilder.Entity<Users>().Property(x => x.FirstName).IsRequired(false);

            modelBuilder.Entity<Users>().Property(x => x.LastName).IsRequired(true);

            base.OnModelCreating(modelBuilder); 
        }
    }
}
