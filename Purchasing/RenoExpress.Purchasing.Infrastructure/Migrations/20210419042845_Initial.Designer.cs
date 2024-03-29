﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RenoExpress.Purchasing.Infrastructure.Data;

namespace RenoExpress.Purchasing.Infrastructure.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20210419042845_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Purchasing")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RenoExpress.Purchasing.Core.Entities.Purchase", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BranchID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<double?>("CreatedTime")
                        .HasColumnType("float");

                    b.Property<string>("CreatedUserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Document")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Expired")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<double?>("ModifiedTime")
                        .HasColumnType("float");

                    b.Property<string>("ModifiedUserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SupplierID")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("RenoExpress.Purchasing.Core.Entities.PurchaseDetail", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<double?>("CreatedTime")
                        .HasColumnType("float");

                    b.Property<string>("CreatedUserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Expired")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<double?>("ModifiedTime")
                        .HasColumnType("float");

                    b.Property<string>("ModifiedUserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("ProductID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PurchaseId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PurchaseId");

                    b.ToTable("PurchaseDetails");
                });

            modelBuilder.Entity("RenoExpress.Purchasing.Core.Entities.PurchaseDetail", b =>
                {
                    b.HasOne("RenoExpress.Purchasing.Core.Entities.Purchase", "Purchase")
                        .WithMany("PurchaseDetails")
                        .HasForeignKey("PurchaseId");

                    b.Navigation("Purchase");
                });

            modelBuilder.Entity("RenoExpress.Purchasing.Core.Entities.Purchase", b =>
                {
                    b.Navigation("PurchaseDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
