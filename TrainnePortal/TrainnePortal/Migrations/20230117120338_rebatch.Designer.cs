﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrainnePortal.Models.User;

#nullable disable

namespace TrainnePortal.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230117120338_rebatch")]
    partial class rebatch
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TrainnePortal.Models.User.BatchModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Course1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Course2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Course3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Course4")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmpId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("batchId")
                        .HasColumnType("int");

                    b.Property<string>("batchName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BatchDetails");
                });

            modelBuilder.Entity("TrainnePortal.Models.User.Registration", b =>
                {
                    b.Property<int>("EmployeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("birthDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("branch")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("college")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("degree")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("father_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("mobile_number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("passOutYear")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("pincode")
                        .HasColumnType("int");

                    b.HasKey("EmployeId");

                    b.ToTable("TrainneDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
