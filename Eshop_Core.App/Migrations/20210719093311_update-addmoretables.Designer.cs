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
    [Migration("20210719093311_update-addmoretables")]
    partial class updateaddmoretables
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

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("CategoryId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("CategoryToProducts");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            ProductId = 1
                        },
                        new
                        {
                            CategoryId = 2,
                            ProductId = 1
                        },
                        new
                        {
                            CategoryId = 3,
                            ProductId = 1
                        },
                        new
                        {
                            CategoryId = 4,
                            ProductId = 1
                        },
                        new
                        {
                            CategoryId = 1,
                            ProductId = 2
                        },
                        new
                        {
                            CategoryId = 2,
                            ProductId = 2
                        },
                        new
                        {
                            CategoryId = 3,
                            ProductId = 2
                        },
                        new
                        {
                            CategoryId = 4,
                            ProductId = 2
                        },
                        new
                        {
                            CategoryId = 1,
                            ProductId = 3
                        },
                        new
                        {
                            CategoryId = 2,
                            ProductId = 3
                        },
                        new
                        {
                            CategoryId = 3,
                            ProductId = 3
                        },
                        new
                        {
                            CategoryId = 4,
                            ProductId = 3
                        });
                });

            modelBuilder.Entity("Eshop_Core.App.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Price")
                        .HasColumnType("Money");

                    b.Property<int>("QuantityInStok")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Price = 854.0m,
                            QuantityInStok = 5
                        },
                        new
                        {
                            Id = 2,
                            Price = 3302.0m,
                            QuantityInStok = 8
                        },
                        new
                        {
                            Id = 3,
                            Price = 2500m,
                            QuantityInStok = 3
                        });
                });

            modelBuilder.Entity("Eshop_Core.App.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ItemId")
                        .IsUnique();

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "آموزش Asp.Net Core 3 پروژه محور ASP.NET Core بر پایه‌ی NET Core.استوار است و نگارشی از NET.محسوب می شود که مستقل از سیستم عامل و بدون واسط برنامه نویسی ویندوز عمل می کند.ویندوز هنوز هم سیستم عاملی برتر به حساب می آید ولی برنامه های وب نه تنها روز به روز از کاربرد و اهمیت بیشتری برخوردار می‌شوند بلکه باید بر روی سکوهای دیگری مانند فضای ابری(Cloud) هم بتوانند میزبانی(Host) شوند، مایکروسافت با معرفی ASP.NET Core گستره کارکرد NET.را افزایش داده است.به این معنی که می‌توان برنامه‌های کاربردی ASP.NET Core را بر روی بازه‌ی گسترده ای از محیط‌های مختلف میزبانی کرد هم‌اکنون می‌توانید پروژه های وب را برای Linux یا macOS هم تولید کنید.",
                            ItemId = 1,
                            Name = "آموزش Asp.Net Core 3 پروژه محور"
                        },
                        new
                        {
                            Id = 2,
                            Description = "در سال های گذشته ، کمپانی مایکروسافت با معرفی تکنولوژی های جدید و حرفه ای در زمینه های مختلف ، عرصه را برای سایر کمپانی ها تنگ تر کرده است. اخیرا این غول فناوری با معرفی فریم ورک های ASP.NET Core و همینطور Blazor قدرت خود در زمینه ی وب را به اثبات رسانده است.",
                            ItemId = 2,
                            Name = "آموزش Blazor از مقدماتی تا پیشرفته"
                        },
                        new
                        {
                            Id = 3,
                            Description = "آموزش اپلیکیشن های وب پیش رونده ( PWA ) آموزش PWA از مقدماتی تا پیشرفته وب اپلیکیشن‌های پیش رونده(PWA) نسل جدید اپلیکیشن‌های تحت وب هستند که می‌توانند آینده‌ی اپلیکیشن‌های موبایل را متحول کنند.در این دوره به طور جامع به بررسی آن‌ها خواهیم پرداخت. مزایا و فاکتور هایی که یک وب اپلیکیشن دارا می باشد به صورت زیر می باشد : ریسپانسیو :  رکن اصلی سایت برای PWA ریسپانسیو بودن اپلیکیشن هستش که برای صفحه نمایش کاربران مختلف موبایل و تبلت خود را وفق دهند.",
                            ItemId = 3,
                            Name = "آموزش اپلیکیشن های وب پیش رونده ( PWA )"
                        });
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
                        .HasForeignKey("ProductId")
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
