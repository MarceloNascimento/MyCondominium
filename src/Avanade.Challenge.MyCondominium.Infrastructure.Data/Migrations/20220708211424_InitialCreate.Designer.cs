﻿// <auto-generated />
using System;
using Avanade.Challenge.MyCondominium.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Avanade.Challenge.MyCondominium.Infrastructure.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220708211424_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Avanade.Challenge.MyCondominium.Domain.Entities.Apartment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Block")
                        .HasColumnType("NVARCHAR(100)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Floor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(100)");

                    b.HasKey("Id");

                    b.ToTable("Apartment", (string)null);
                });

            modelBuilder.Entity("Avanade.Challenge.MyCondominium.Domain.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ApartmentId")
                        .HasColumnType("INT");

                    b.Property<int?>("Block")
                        .HasColumnType("int");

                    b.Property<decimal?>("CondominiumFee")
                        .HasColumnType("DECIMAL(7,2)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsResident")
                        .HasColumnType("BIT");

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(100)");

                    b.HasKey("Id");

                    b.HasIndex("ApartmentId");

                    b.ToTable("Person", (string)null);
                });

            modelBuilder.Entity("Avanade.Challenge.MyCondominium.Domain.Entities.Person", b =>
                {
                    b.HasOne("Avanade.Challenge.MyCondominium.Domain.Entities.Apartment", "Apartment")
                        .WithMany()
                        .HasForeignKey("ApartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Apartment");
                });
#pragma warning restore 612, 618
        }
    }
}
