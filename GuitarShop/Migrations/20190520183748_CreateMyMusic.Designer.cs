﻿// <auto-generated />
using MyMusic.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MyMusic.Migrations
{
    [DbContext(typeof(ShopContext))]
    [Migration("20190520183748_CreateMyMusic")]
    partial class CreateMyMusic
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0-preview3.19153.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyMusic.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryID = 1,
                            Name = "Guitars"
                        },
                        new
                        {
                            CategoryID = 2,
                            Name = "Basses"
                        },
                        new
                        {
                            CategoryID = 3,
                            Name = "Drums"
                        });
                });

            modelBuilder.Entity("MyMusic.Models.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryID");

                    b.Property<string>("Code")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProductID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductID = 1,
                            CategoryID = 1,
                            Code = "strat",
                            Name = "Fender Stratocaster",
                            Price = 699m
                        },
                        new
                        {
                            ProductID = 2,
                            CategoryID = 1,
                            Code = "les_paul",
                            Name = "Gibson Les Paul",
                            Price = 1199m
                        },
                        new
                        {
                            ProductID = 3,
                            CategoryID = 1,
                            Code = "sg",
                            Name = "Gibson SG",
                            Price = 2517m
                        },
                        new
                        {
                            ProductID = 4,
                            CategoryID = 1,
                            Code = "fg700s",
                            Name = "Yamaha FG700S",
                            Price = 489.99m
                        },
                        new
                        {
                            ProductID = 5,
                            CategoryID = 1,
                            Code = "washburn",
                            Name = "Washburn D10S",
                            Price = 299m
                        },
                        new
                        {
                            ProductID = 6,
                            CategoryID = 1,
                            Code = "rodriguez",
                            Name = "Rodriguez Caballero 11",
                            Price = 415m
                        },
                        new
                        {
                            ProductID = 7,
                            CategoryID = 2,
                            Code = "precision",
                            Name = "Fender Precision",
                            Price = 799.99m
                        },
                        new
                        {
                            ProductID = 8,
                            CategoryID = 2,
                            Code = "hofner",
                            Name = "Hofner Icon",
                            Price = 499.99m
                        },
                        new
                        {
                            ProductID = 9,
                            CategoryID = 3,
                            Code = "ludwig",
                            Name = "Ludwig 5-piece Drum Set with Cymbals",
                            Price = 699.99m
                        },
                        new
                        {
                            ProductID = 10,
                            CategoryID = 3,
                            Code = "tama",
                            Name = "Tama 5-Piece Drum Set with Cymbals",
                            Price = 799.99m
                        });
                });

            modelBuilder.Entity("MyMusic.Models.Product", b =>
                {
                    b.HasOne("MyMusic.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
