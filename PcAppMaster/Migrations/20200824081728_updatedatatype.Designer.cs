﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PcAppMaster.Models.Data;

namespace PcAppMaster.Migrations
{
    [DbContext(typeof(PcDbContext))]
    [Migration("20200824081728_updatedatatype")]
    partial class updatedatatype
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0-preview.7.20365.15");

            modelBuilder.Entity("PcAppMaster.Models.Device", b =>
                {
                    b.Property<int>("Dvid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("DvNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HpId")
                        .HasColumnType("int");

                    b.HasKey("Dvid");

                    b.HasIndex("HpId");

                    b.ToTable("devices");
                });

            modelBuilder.Entity("PcAppMaster.Models.Drinks", b =>
                {
                    b.Property<int>("DrDrinkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("DrDrinkName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DrDrinkPrice")
                        .HasColumnType("int");

                    b.Property<int>("DrDrinkQut")
                        .HasColumnType("int");

                    b.HasKey("DrDrinkId");

                    b.ToTable("drinks");
                });

            modelBuilder.Entity("PcAppMaster.Models.HoursPrice", b =>
                {
                    b.Property<int>("HpId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<double>("HpMultiPrice")
                        .HasColumnType("float");

                    b.Property<double>("HpSinglePrice")
                        .HasColumnType("float");

                    b.Property<string>("HpTypePc")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HpId");

                    b.ToTable("hoursPrices");
                });

            modelBuilder.Entity("PcAppMaster.Models.Receipt", b =>
                {
                    b.Property<Guid>("BillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("RecDrinkPrice")
                        .HasColumnType("int");

                    b.Property<DateTime>("RecEndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("RecHoursPrice")
                        .HasColumnType("int");

                    b.Property<bool>("RecHoursType")
                        .HasColumnType("bit");

                    b.Property<string>("RecPcName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RecReceiptDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RecStartTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("RecTotal")
                        .HasColumnType("int");

                    b.Property<double>("RecTotalMinutes")
                        .HasColumnType("float");

                    b.Property<int?>("ReceiptForDrinksRfDrinkId")
                        .HasColumnType("int");

                    b.HasKey("BillId");

                    b.HasIndex("ReceiptForDrinksRfDrinkId");

                    b.ToTable("receipts");
                });

            modelBuilder.Entity("PcAppMaster.Models.ReceiptForDrinks", b =>
                {
                    b.Property<int>("RfDrinkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<Guid>("BillId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("DrDrinkId")
                        .HasColumnType("int");

                    b.Property<Guid?>("ReceiptBillId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RfDrink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RfDrinkQut")
                        .HasColumnType("int");

                    b.Property<int>("RfDrinkTotal")
                        .HasColumnType("int");

                    b.Property<int>("RfDrinkprice")
                        .HasColumnType("int");

                    b.HasKey("RfDrinkId");

                    b.HasIndex("ReceiptBillId");

                    b.ToTable("receiptForDrinks");
                });

            modelBuilder.Entity("PcAppMaster.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("UserKind")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserPhone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("PcAppMaster.Models.Device", b =>
                {
                    b.HasOne("PcAppMaster.Models.HoursPrice", "HoursPrice")
                        .WithMany()
                        .HasForeignKey("HpId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PcAppMaster.Models.Receipt", b =>
                {
                    b.HasOne("PcAppMaster.Models.ReceiptForDrinks", "ReceiptForDrinks")
                        .WithMany()
                        .HasForeignKey("ReceiptForDrinksRfDrinkId");
                });

            modelBuilder.Entity("PcAppMaster.Models.ReceiptForDrinks", b =>
                {
                    b.HasOne("PcAppMaster.Models.Receipt", null)
                        .WithMany("RfDrinkId")
                        .HasForeignKey("ReceiptBillId");
                });
#pragma warning restore 612, 618
        }
    }
}
