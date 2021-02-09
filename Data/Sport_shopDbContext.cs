using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sport_shop.Areas.Identity.Data;
using Sport_shop.Models;

namespace Sport_shop.Data
{
    public class Sport_shopDbContext : DbContext
    {
        public Sport_shopDbContext(DbContextOptions<Sport_shopDbContext> options) : base(options)
        {
        }

        public DbSet<Bagpack> Bagpacks { get; set; }
        public DbSet<Bicycle> Bicycles { get; set; }
        public DbSet<Shoe> Shoes { get; set; }
        public DbSet<Football> Footballs { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Cart> Carts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bagpack>().ToTable("Bagpack");
            modelBuilder.Entity<Bicycle>().ToTable("Bicycle");
            modelBuilder.Entity<Shoe>().ToTable("Shoe");
            modelBuilder.Entity<Football>().ToTable("Football");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Client>().ToTable("Client");
            modelBuilder.Entity<Cart>().ToTable("Cart");
            
        }
    }
}
