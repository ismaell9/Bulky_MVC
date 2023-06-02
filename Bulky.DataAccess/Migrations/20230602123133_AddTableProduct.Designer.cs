﻿// <auto-generated />
using BulkyBook.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BulkyBook.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230602123133_AddTableProduct")]
    partial class AddTableProduct
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BulkyBook.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayOrder = 1,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 2,
                            DisplayOrder = 2,
                            Name = "Comedy"
                        },
                        new
                        {
                            Id = 3,
                            DisplayOrder = 3,
                            Name = "SciFi"
                        });
                });

            modelBuilder.Entity("BulkyBook.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ListPrice")
                        .HasColumnType("float");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<double>("Price100")
                        .HasColumnType("float");

                    b.Property<double>("Price50")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Hamed",
                            Description = "Book About EveryDay's life",
                            ISBN = "857-6-11-123455-5",
                            ListPrice = 5.25,
                            Price = 6.4500000000000002,
                            Price100 = 8.9499999999999993,
                            Price50 = 9.4000000000000004,
                            Title = "Life Book"
                        },
                        new
                        {
                            Id = 2,
                            Author = "Sameh",
                            Description = "Book About Good Partener in life",
                            ISBN = "978-3-16-148410-0",
                            ListPrice = 7.5499999999999998,
                            Price = 5.4100000000000001,
                            Price100 = 4.0499999999999998,
                            Price50 = 8.1999999999999993,
                            Title = "Partner in Life Book"
                        },
                        new
                        {
                            Id = 3,
                            Author = "Ahmed",
                            Description = "Book About How to be a SuperHero",
                            ISBN = "957-2-14-122014-2",
                            ListPrice = 2.5699999999999998,
                            Price = 7.75,
                            Price100 = 4.7999999999999998,
                            Price50 = 2.9900000000000002,
                            Title = "SuperHeros mood"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}