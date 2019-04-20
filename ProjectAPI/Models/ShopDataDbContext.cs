using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Models
{
    public class ShopDataDbContext:DbContext
    {
        public ShopDataDbContext()
        {

        }
        public ShopDataDbContext
           (DbContextOptions<ShopDataDbContext> options)
           : base(options)
        { }

        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Payment> Payments  { get; set; }
        public DbSet<Brand> Brands { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=TRD-517; Initial Catalog=ShoppingDemoooo2;Integrated Security=true;");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderProduct>(build =>
            {
                build.HasKey(t => new { t.OrderId, t.ProductId });
            });
            modelBuilder.Entity<Product>()
                .HasOne(c => c.Category)
                .WithMany(p => p.Products)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Product>()
          .HasOne(v => v.Vendor)
          .WithMany(p => p.Products)
          .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Feedback>()
             .HasOne(c => c.Customer)
             .WithMany(f => f.Feedbacks)
             .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Order>()
            .HasOne(c => c.Customer)
            .WithMany(o => o.Orders)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.Property(e => e.VendorName)
                .HasColumnName("VendorName")
                .HasMaxLength(25)
            .IsUnicode(false);
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
