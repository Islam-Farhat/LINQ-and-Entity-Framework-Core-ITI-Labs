﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using lab2.Models;

#nullable disable

namespace lab2.Migrations
{
    [DbContext(typeof(JouralismContext))]
    [Migration("20230306132809_Initial1")]
    partial class Initial1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("lab2.Models.Auther", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("age")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("hiredate")
                        .HasColumnType("datetime2");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("authers");
                });

            modelBuilder.Entity("lab2.Models.NewDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("newId")
                        .HasColumnType("int");

                    b.Property<string>("pdf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("photo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("newId");

                    b.ToTable("newDetails");
                });

            modelBuilder.Entity("lab2.Models.News", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("autherId")
                        .HasColumnType("int");

                    b.Property<string>("bref")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("datetime")
                        .HasColumnType("datetime2");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("autherId");

                    b.ToTable("news");
                });

            modelBuilder.Entity("lab2.Models.NewDetails", b =>
                {
                    b.HasOne("lab2.Models.News", "News")
                        .WithMany("NewDetails")
                        .HasForeignKey("newId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("News");
                });

            modelBuilder.Entity("lab2.Models.News", b =>
                {
                    b.HasOne("lab2.Models.Auther", "Auther")
                        .WithMany("News")
                        .HasForeignKey("autherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Auther");
                });

            modelBuilder.Entity("lab2.Models.Auther", b =>
                {
                    b.Navigation("News");
                });

            modelBuilder.Entity("lab2.Models.News", b =>
                {
                    b.Navigation("NewDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
