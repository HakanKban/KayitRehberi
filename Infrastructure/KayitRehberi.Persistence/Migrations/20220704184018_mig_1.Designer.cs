﻿// <auto-generated />
using System;
using KayitRehberi.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace KayitRehberi.Persistence.Migrations
{
    [DbContext(typeof(KayiRehberiDbContext))]
    [Migration("20220704184018_mig_1")]
    partial class mig_1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("KayitRehberi.Domain.Entities.CommercialActivity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<long>("ServiceCharge")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("ServiceDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ServiceName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("CommercialActivities");
                });

            modelBuilder.Entity("KayitRehberi.Domain.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("Photo")
                        .HasColumnType("text");

                    b.Property<string>("SurName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("KayitRehberi.Domain.Entities.CommercialActivity", b =>
                {
                    b.HasOne("KayitRehberi.Domain.Entities.Customer", "Customer")
                        .WithMany("commercialActivities")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("KayitRehberi.Domain.Entities.Customer", b =>
                {
                    b.Navigation("commercialActivities");
                });
#pragma warning restore 612, 618
        }
    }
}
