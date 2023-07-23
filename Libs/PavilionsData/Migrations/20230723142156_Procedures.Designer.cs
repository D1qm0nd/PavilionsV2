﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PavilionsData.PavilionsModel.Context;

#nullable disable

namespace PavilionsData.Migrations
{
    [DbContext(typeof(PavilionsDbContext))]
    [Migration("20230723142156_Procedures")]
    partial class Procedures
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PavilionsData.PavilionsModel.Tables.City", b =>
                {
                    b.Property<int>("Id_City")
                        .HasColumnType("int");

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<string>("RecordStatus")
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.HasKey("Id_City");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("PavilionsData.PavilionsModel.Tables.Employee", b =>
                {
                    b.Property<int>("Id_Employee")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<int>("Id_Role")
                        .HasColumnType("int");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Middlename")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Name")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Password")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Surname")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("Id_Employee");

                    b.HasIndex("Id_Role");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("PavilionsData.PavilionsModel.Tables.Pavilion", b =>
                {
                    b.Property<int>("Id_Pavilion")
                        .HasColumnType("int");

                    b.Property<double>("AddedValueCoefficient")
                        .HasColumnType("float");

                    b.Property<double>("Area")
                        .HasColumnType("float");

                    b.Property<int>("Floor")
                        .HasColumnType("int");

                    b.Property<int>("Id_PavilionsStatus")
                        .HasColumnType("int");

                    b.Property<int>("Id_ShoppingCenter")
                        .HasMaxLength(80)
                        .HasColumnType("int");

                    b.Property<string>("Number")
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("RecordStatus")
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.HasKey("Id_Pavilion");

                    b.HasIndex("Id_PavilionsStatus");

                    b.HasIndex("Id_ShoppingCenter");

                    b.ToTable("Pavilions");
                });

            modelBuilder.Entity("PavilionsData.PavilionsModel.Tables.PavilionStatus", b =>
                {
                    b.Property<int>("Id_PavilionsStatus")
                        .HasColumnType("int");

                    b.Property<string>("PavilionsStatusName")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("RecordStatus")
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.HasKey("Id_PavilionsStatus");

                    b.ToTable("PavilionsStatuses");
                });

            modelBuilder.Entity("PavilionsData.PavilionsModel.Tables.Rental", b =>
                {
                    b.Property<int>("Id_Rental")
                        .HasColumnType("int");

                    b.Property<string>("AdditionalInfo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id_Employee")
                        .HasColumnType("int");

                    b.Property<int>("Id_Pavilion")
                        .HasColumnType("int");

                    b.Property<int>("Id_RentalStatus")
                        .HasColumnType("int");

                    b.Property<int>("Id_Tenant")
                        .HasColumnType("int");

                    b.Property<string>("RecordStatus")
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id_Rental");

                    b.HasIndex("Id_Employee");

                    b.HasIndex("Id_Pavilion");

                    b.HasIndex("Id_RentalStatus");

                    b.HasIndex("Id_Tenant");

                    b.ToTable("Rentals");
                });

            modelBuilder.Entity("PavilionsData.PavilionsModel.Tables.RentalsStatus", b =>
                {
                    b.Property<int>("Id_RentalStatus")
                        .HasColumnType("int");

                    b.Property<string>("RecordStatus")
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<string>("RentalStatusName")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.HasKey("Id_RentalStatus");

                    b.ToTable("RentalsStatuses");
                });

            modelBuilder.Entity("PavilionsData.PavilionsModel.Tables.Role", b =>
                {
                    b.Property<int>("Id_Role")
                        .HasColumnType("int");

                    b.Property<string>("RecordStatus")
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.HasKey("Id_Role");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("PavilionsData.PavilionsModel.Tables.ShoppingCenter", b =>
                {
                    b.Property<int>("Id_ShoppingCenter")
                        .HasColumnType("int");

                    b.Property<double>("AddedValueCoefficient")
                        .HasColumnType("float");

                    b.Property<int>("FloorsNumber")
                        .HasColumnType("int");

                    b.Property<int>("Id_City")
                        .HasColumnType("int");

                    b.Property<int>("Id_ShoppingCenterStatus")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<int>("PavilionsCount")
                        .HasColumnType("int");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("varbinary(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("RecordStatus")
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.HasKey("Id_ShoppingCenter");

                    b.HasIndex("Id_City");

                    b.HasIndex("Id_ShoppingCenterStatus");

                    b.ToTable("ShoppingCenters");
                });

            modelBuilder.Entity("PavilionsData.PavilionsModel.Tables.ShoppingCentersStatus", b =>
                {
                    b.Property<int>("Id_ShoppingStatus")
                        .HasColumnType("int");

                    b.Property<string>("RecordStatus")
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<string>("ShoppingStatusName")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.HasKey("Id_ShoppingStatus");

                    b.ToTable("ShoppingCentersStatuses");
                });

            modelBuilder.Entity("PavilionsData.PavilionsModel.Tables.Tenant", b =>
                {
                    b.Property<int>("Id_Tenant")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<string>("RecordStatus")
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.HasKey("Id_Tenant");

                    b.ToTable("Tenants");
                });

            modelBuilder.Entity("PavilionsData.PavilionsModel.Tables.Employee", b =>
                {
                    b.HasOne("PavilionsData.PavilionsModel.Tables.Role", "Role")
                        .WithMany()
                        .HasForeignKey("Id_Role")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("PavilionsData.PavilionsModel.Tables.Pavilion", b =>
                {
                    b.HasOne("PavilionsData.PavilionsModel.Tables.PavilionStatus", "PavilionStatus")
                        .WithMany()
                        .HasForeignKey("Id_PavilionsStatus")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PavilionsData.PavilionsModel.Tables.ShoppingCenter", "ShoppingCenter")
                        .WithMany()
                        .HasForeignKey("Id_ShoppingCenter")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PavilionStatus");

                    b.Navigation("ShoppingCenter");
                });

            modelBuilder.Entity("PavilionsData.PavilionsModel.Tables.Rental", b =>
                {
                    b.HasOne("PavilionsData.PavilionsModel.Tables.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("Id_Employee")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PavilionsData.PavilionsModel.Tables.Pavilion", "Pavilion")
                        .WithMany()
                        .HasForeignKey("Id_Pavilion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PavilionsData.PavilionsModel.Tables.RentalsStatus", "RentalsStatus")
                        .WithMany()
                        .HasForeignKey("Id_RentalStatus")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PavilionsData.PavilionsModel.Tables.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("Id_Tenant")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Pavilion");

                    b.Navigation("RentalsStatus");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("PavilionsData.PavilionsModel.Tables.ShoppingCenter", b =>
                {
                    b.HasOne("PavilionsData.PavilionsModel.Tables.City", "City")
                        .WithMany()
                        .HasForeignKey("Id_City")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PavilionsData.PavilionsModel.Tables.ShoppingCentersStatus", "ShoppingCentersStatus")
                        .WithMany()
                        .HasForeignKey("Id_ShoppingCenterStatus")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("ShoppingCentersStatus");
                });
#pragma warning restore 612, 618
        }
    }
}
