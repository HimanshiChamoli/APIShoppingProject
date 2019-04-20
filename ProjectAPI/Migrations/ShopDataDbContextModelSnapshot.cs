﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectAPI.Models;

namespace ProjectAPI.Migrations
{
    [DbContext(typeof(ShopDataDbContext))]
    partial class ShopDataDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjectAPI.Models.Brand", b =>
                {
                    b.Property<int>("BrandId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrandDescription");

                    b.Property<string>("BrandName");

                    b.HasKey("BrandId");

                    b.ToTable("brands");
                });

            modelBuilder.Entity("ProjectAPI.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("Country");

                    b.Property<string>("EmailId");

                    b.Property<string>("FirstName");

                    b.Property<string>("Gender");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<long>("PhoneNo");

                    b.Property<bool>("Shipping_Address");

                    b.Property<string>("Username");

                    b.Property<int>("Zip");

                    b.Property<string>("state");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("ProjectAPI.Models.Feedback", b =>
                {
                    b.Property<int>("FeedbackId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment");

                    b.Property<int>("CustomerId");

                    b.Property<string>("EmailId");

                    b.Property<long>("PhoneNo");

                    b.HasKey("FeedbackId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("ProjectAPI.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId");

                    b.Property<DateTime>("OrderDate");

                    b.Property<float>("OrderPrice");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ProjectAPI.Models.OrderProduct", b =>
                {
                    b.Property<int>("OrderId");

                    b.Property<int>("ProductId");

                    b.Property<int>("Quantity");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderProducts");
                });

            modelBuilder.Entity("ProjectAPI.Models.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Card_no");

                    b.Property<int>("CustomerId");

                    b.Property<DateTime>("Date");

                    b.Property<int>("OrderId");

                    b.Property<string>("PaymentStripeId");

                    b.Property<int>("amount");

                    b.HasKey("PaymentId");

                    b.HasIndex("OrderId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("ProjectAPI.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BrandId");

                    b.Property<int>("ProductCategoryId");

                    b.Property<string>("ProductDescription");

                    b.Property<string>("ProductImage");

                    b.Property<string>("ProductName");

                    b.Property<float>("ProductPrice");

                    b.Property<int>("ProductQty");

                    b.Property<int>("VendorId");

                    b.HasKey("ProductId");

                    b.HasIndex("BrandId");

                    b.HasIndex("ProductCategoryId");

                    b.HasIndex("VendorId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ProjectAPI.Models.ProductCategory", b =>
                {
                    b.Property<int>("ProductCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryDescription");

                    b.Property<string>("CategoryName");

                    b.HasKey("ProductCategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ProjectAPI.Models.Vendor", b =>
                {
                    b.Property<int>("VendorId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmailId");

                    b.Property<double>("PhoneNo");

                    b.Property<string>("VendorDescription");

                    b.Property<string>("VendorName")
                        .HasColumnName("VendorName")
                        .HasMaxLength(25)
                        .IsUnicode(false);

                    b.HasKey("VendorId");

                    b.ToTable("Vendors");
                });

            modelBuilder.Entity("ProjectAPI.Models.Feedback", b =>
                {
                    b.HasOne("ProjectAPI.Models.Customer", "Customer")
                        .WithMany("Feedbacks")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjectAPI.Models.Order", b =>
                {
                    b.HasOne("ProjectAPI.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjectAPI.Models.OrderProduct", b =>
                {
                    b.HasOne("ProjectAPI.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjectAPI.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjectAPI.Models.Payment", b =>
                {
                    b.HasOne("ProjectAPI.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjectAPI.Models.Product", b =>
                {
                    b.HasOne("ProjectAPI.Models.Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId");

                    b.HasOne("ProjectAPI.Models.ProductCategory", "Category")
                        .WithMany("Products")
                        .HasForeignKey("ProductCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjectAPI.Models.Vendor", "Vendor")
                        .WithMany("Products")
                        .HasForeignKey("VendorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
