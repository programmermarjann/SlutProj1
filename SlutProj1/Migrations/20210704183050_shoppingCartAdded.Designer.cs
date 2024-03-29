﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SlutProj1.Models;

namespace SlutProj1.Migrations
{
    [DbContext(typeof(SlutDbContext))]
    [Migration("20210704183050_shoppingCartAdded")]
    partial class shoppingCartAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SlutProj1.Models.Cup", b =>
                {
                    b.Property<int>("CupID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("CupID");

                    b.ToTable("Cup");
                });

            modelBuilder.Entity("SlutProj1.Models.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("Product")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Size")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderID");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("SlutProj1.Models.ShoppingCartItems", b =>
                {
                    b.Property<int>("ShopingCartItemsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int?>("CupID")
                        .HasColumnType("int");

                    b.Property<string>("ShoppingCartID")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ShopingCartItemsID");

                    b.HasIndex("CupID");

                    b.ToTable("ShoppingCartItems");
                });

            modelBuilder.Entity("SlutProj1.Models.Tshirt", b =>
                {
                    b.Property<int>("TshirtID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Size")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TshirtID");

                    b.ToTable("Tshirts");
                });

            modelBuilder.Entity("SlutProj1.Models.ShoppingCartItems", b =>
                {
                    b.HasOne("SlutProj1.Models.Cup", "Cup")
                        .WithMany()
                        .HasForeignKey("CupID");

                    b.Navigation("Cup");
                });
#pragma warning restore 612, 618
        }
    }
}
