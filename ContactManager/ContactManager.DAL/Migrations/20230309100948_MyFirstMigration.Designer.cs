﻿// <auto-generated />
using System;
using ContactManager.DAL.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ContactManager.DAL.Migrations
{
    [DbContext(typeof(ContactManagerDbContext))]
    [Migration("20230309100948_MyFirstMigration")]
    partial class MyFirstMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ContactManager.DAL.Entities.ContactData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Married")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("ContactData");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateOfBirth = new DateTime(2008, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Married = true,
                            Name = "Anna",
                            Phone = "0987654321",
                            Salary = 5000m
                        },
                        new
                        {
                            Id = 2,
                            DateOfBirth = new DateTime(2001, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Married = false,
                            Name = "Bob",
                            Phone = "0987644441",
                            Salary = 4000m
                        },
                        new
                        {
                            Id = 3,
                            DateOfBirth = new DateTime(1999, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Married = false,
                            Name = "Tom",
                            Phone = "0987644490",
                            Salary = 14000m
                        },
                        new
                        {
                            Id = 4,
                            DateOfBirth = new DateTime(2003, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Married = false,
                            Name = "Maria",
                            Phone = "0667644441",
                            Salary = 8000m
                        },
                        new
                        {
                            Id = 5,
                            DateOfBirth = new DateTime(1999, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Married = false,
                            Name = "David",
                            Phone = "0777644490",
                            Salary = 10000m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
