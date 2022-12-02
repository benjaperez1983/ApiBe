﻿// <auto-generated />
using System;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApiBEDbContext))]
    [Migration("20221202130426_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DomainModel.Entities.PricesDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<Guid?>("PricesHeaderguid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double?>("adjclose")
                        .HasColumnType("float");

                    b.Property<double?>("amount")
                        .HasColumnType("float");

                    b.Property<double?>("close")
                        .HasColumnType("float");

                    b.Property<double?>("data")
                        .HasColumnType("float");

                    b.Property<int?>("date")
                        .HasColumnType("int");

                    b.Property<double?>("high")
                        .HasColumnType("float");

                    b.Property<double?>("low")
                        .HasColumnType("float");

                    b.Property<double?>("open")
                        .HasColumnType("float");

                    b.Property<string>("type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("volume")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PricesHeaderguid");

                    b.ToTable("PricesDetail");
                });

            modelBuilder.Entity("DomainModel.Entities.PricesHeader", b =>
                {
                    b.Property<Guid>("guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("created")
                        .HasColumnType("datetime2");

                    b.Property<string>("symbol")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("guid");

                    b.ToTable("PricesHeader");
                });

            modelBuilder.Entity("DomainModel.Entities.PricesDetail", b =>
                {
                    b.HasOne("DomainModel.Entities.PricesHeader", null)
                        .WithMany("pricesDetail")
                        .HasForeignKey("PricesHeaderguid");
                });

            modelBuilder.Entity("DomainModel.Entities.PricesHeader", b =>
                {
                    b.Navigation("pricesDetail");
                });
#pragma warning restore 612, 618
        }
    }
}
