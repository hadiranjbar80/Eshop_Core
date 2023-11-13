﻿// <auto-generated />
using Eshop_Core.App.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Eshop_Core.App.Migrations
{
    [DbContext(typeof(EshopContext))]
    [Migration("20210719092135_addmoretables")]
    partial class addmoretables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Eshop_Core.App.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Asp.Net Core 3",
                            Name = "Asp.Net Core"
                        },
                        new
                        {
                            Id = 2,
                            Description = "گروه لباس ورزشی",
                            Name = "لباس ورزشی"
                        },
                        new
                        {
                            Id = 3,
                            Description = "گروه ساعت مچی",
                            Name = "ساعت مچی"
                        },
                        new
                        {
                            Id = 4,
                            Description = "گروه لوازم منزل",
                            Name = "لوازم منزل"
                        });
                });

            modelBuilder.Entity("Eshop_Core.App.Models.CategoryToProduct", b =>
                {
                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("productId")
                        .HasColumnType("int");

                    b.HasKey("CategoryId", "productId");

                    b.HasIndex("productId");

                    b.ToTable("CategoryToProducts");
                });

            modelBuilder.Entity("Eshop_Core.App.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("QuantityInStok")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Eshop_Core.App.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ItemId")
                        .IsUnique();

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Eshop_Core.App.Models.CategoryToProduct", b =>
                {
                    b.HasOne("Eshop_Core.App.Models.Category", "Category")
                        .WithMany("CategoryToProducts")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Eshop_Core.App.Models.Product", "Product")
                        .WithMany("CategoryToProducts")
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Eshop_Core.App.Models.Product", b =>
                {
                    b.HasOne("Eshop_Core.App.Models.Item", "Item")
                        .WithOne("Product")
                        .HasForeignKey("Eshop_Core.App.Models.Product", "ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("Eshop_Core.App.Models.Category", b =>
                {
                    b.Navigation("CategoryToProducts");
                });

            modelBuilder.Entity("Eshop_Core.App.Models.Item", b =>
                {
                    b.Navigation("Product");
                });

            modelBuilder.Entity("Eshop_Core.App.Models.Product", b =>
                {
                    b.Navigation("CategoryToProducts");
                });
#pragma warning restore 612, 618
        }
    }
}