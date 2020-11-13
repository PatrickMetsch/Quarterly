﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Quarterly.Models;

namespace Quarterly.Migrations
{
    [DbContext(typeof(SalesContext))]
    [Migration("20201113051954_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0");

            modelBuilder.Entity("Quarterly.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfHire")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<int>("ManagerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1,
                            DateOfBirth = new DateTime(1968, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfHire = new DateTime(2010, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Tommy",
                            LastName = "Creo",
                            ManagerId = 0
                        },
                        new
                        {
                            EmployeeId = 2,
                            DateOfBirth = new DateTime(1970, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfHire = new DateTime(2010, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Izzy",
                            LastName = "Creo",
                            ManagerId = 1
                        },
                        new
                        {
                            EmployeeId = 3,
                            DateOfBirth = new DateTime(2001, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfHire = new DateTime(2013, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Donovan",
                            LastName = "Sapien",
                            ManagerId = 1
                        });
                });

            modelBuilder.Entity("Quarterly.Models.Sales", b =>
                {
                    b.Property<int>("SalesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double?>("Amount")
                        .IsRequired()
                        .HasColumnType("REAL");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Quarter")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Year")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.HasKey("SalesId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Sales");

                    b.HasData(
                        new
                        {
                            SalesId = 1,
                            Amount = 87192.0,
                            EmployeeId = 2,
                            Quarter = 3,
                            Year = 2018
                        },
                        new
                        {
                            SalesId = 2,
                            Amount = 6715.0,
                            EmployeeId = 1,
                            Quarter = 2,
                            Year = 2013
                        },
                        new
                        {
                            SalesId = 3,
                            Amount = 44511.0,
                            EmployeeId = 3,
                            Quarter = 4,
                            Year = 2015
                        },
                        new
                        {
                            SalesId = 4,
                            Amount = 76141.0,
                            EmployeeId = 1,
                            Quarter = 4,
                            Year = 2016
                        },
                        new
                        {
                            SalesId = 5,
                            Amount = 91671.0,
                            EmployeeId = 3,
                            Quarter = 1,
                            Year = 2017
                        },
                        new
                        {
                            SalesId = 6,
                            Amount = 11341.0,
                            EmployeeId = 2,
                            Quarter = 1,
                            Year = 2013
                        });
                });

            modelBuilder.Entity("Quarterly.Models.Sales", b =>
                {
                    b.HasOne("Quarterly.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}