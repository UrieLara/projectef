﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using projectef;

#nullable disable

namespace projectef.Migrations
{
    [DbContext(typeof(iTaskContext))]
    [Migration("20241104145813_ConfigureWarningsiTaskContext")]
    partial class ConfigureWarningsiTaskContext
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-rc.2.24474.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("projectef.Models.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("CategoryId");

                    b.ToTable("Category", (string)null);

                    b.HasData(
                        new
                        {
                            CategoryId = new Guid("c27fda36-f8f1-4c56-9435-64bcf01689f7"),
                            Name = "Actividades pendientes",
                            Weight = 20
                        },
                        new
                        {
                            CategoryId = new Guid("c27fda36-f8f1-4c56-9435-64bcf0168902"),
                            Name = "Actividades personales",
                            Weight = 50
                        });
                });

            modelBuilder.Entity("projectef.Models.iTask", b =>
                {
                    b.Property<Guid>("iTaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AssignedPerson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("iTaskPriority")
                        .HasColumnType("int");

                    b.HasKey("iTaskId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Task", (string)null);

                    b.HasData(
                        new
                        {
                            iTaskId = new Guid("1e4e8aef-411f-45c6-bef0-581660f9b42c"),
                            CategoryId = new Guid("c27fda36-f8f1-4c56-9435-64bcf01689f7"),
                            CreationDate = new DateTime(2024, 11, 4, 11, 58, 12, 440, DateTimeKind.Local).AddTicks(3535),
                            Title = "Revisar pago de servicios",
                            iTaskPriority = 0
                        },
                        new
                        {
                            iTaskId = new Guid("1e4e8aef-411f-45c6-bef0-581660f9b411"),
                            CategoryId = new Guid("c27fda36-f8f1-4c56-9435-64bcf0168902"),
                            CreationDate = new DateTime(2024, 11, 4, 11, 58, 12, 442, DateTimeKind.Local).AddTicks(6412),
                            Title = "Pagar tarjeta",
                            iTaskPriority = 1
                        });
                });

            modelBuilder.Entity("projectef.Models.iTask", b =>
                {
                    b.HasOne("projectef.Models.Category", "Category")
                        .WithMany("Tasks")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("projectef.Models.Category", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
