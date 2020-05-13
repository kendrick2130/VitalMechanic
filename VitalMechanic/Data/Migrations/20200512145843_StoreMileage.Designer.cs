﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VitalMechanic.Data;

namespace VitalMechanic.Migrations
{
    [DbContext(typeof(VehiclesContext))]
    [Migration("20200512145843_StoreMileage")]
    partial class StoreMileage
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VitalMechanic.Models.CarGarage", b =>
                {
                    b.Property<int>("CarGarageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CarMake")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CarModels")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CarYear")
                        .HasColumnType("int");

                    b.Property<string>("DriveTran")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EngineSize")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Transmission")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CarGarageID");

                    b.ToTable("CarGarage");
                });

            modelBuilder.Entity("VitalMechanic.Models.CarMakes", b =>
                {
                    b.Property<int>("CarMakesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Make")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CarMakesId");

                    b.ToTable("CarMakes");
                });

            modelBuilder.Entity("VitalMechanic.Models.CarMileageMilestone", b =>
                {
                    b.Property<int>("CarMileageMilestoneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("MaintenanceCompletionDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MileageId")
                        .HasColumnType("int");

                    b.Property<int>("UserCarsId")
                        .HasColumnType("int");

                    b.HasKey("CarMileageMilestoneId");

                    b.HasIndex("MileageId");

                    b.ToTable("CarMileageMilestone");
                });

            modelBuilder.Entity("VitalMechanic.Models.CarModels", b =>
                {
                    b.Property<int>("CarModelsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarMakesId")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CarModelsId");

                    b.HasIndex("CarMakesId");

                    b.ToTable("CarModels");
                });

            modelBuilder.Entity("VitalMechanic.Models.CarYear", b =>
                {
                    b.Property<int>("CarYearId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("YearOfMake")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CarYearId");

                    b.ToTable("CarYear");
                });

            modelBuilder.Entity("VitalMechanic.Models.DriveTran", b =>
                {
                    b.Property<int>("DriveTranID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DriveTranType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DriveTranID");

                    b.ToTable("DriveTrans");
                });

            modelBuilder.Entity("VitalMechanic.Models.EngineSize", b =>
                {
                    b.Property<int>("EngineSizeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EngineType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EngineSizeId");

                    b.ToTable("EngineSizes");
                });

            modelBuilder.Entity("VitalMechanic.Models.Mileage", b =>
                {
                    b.Property<int>("MileageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarGarageId")
                        .HasColumnType("int");

                    b.Property<int>("CarMileage")
                        .HasColumnType("int");

                    b.HasKey("MileageId");

                    b.ToTable("Mileage");
                });

            modelBuilder.Entity("VitalMechanic.Models.Transmission", b =>
                {
                    b.Property<int>("TransmissionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TransmissionType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TransmissionID");

                    b.ToTable("Transmissions");
                });

            modelBuilder.Entity("VitalMechanic.Models.CarMileageMilestone", b =>
                {
                    b.HasOne("VitalMechanic.Models.Mileage", "Mileage")
                        .WithMany("CarMileageMilestone")
                        .HasForeignKey("MileageId");
                });

            modelBuilder.Entity("VitalMechanic.Models.CarModels", b =>
                {
                    b.HasOne("VitalMechanic.Models.CarMakes", "Make")
                        .WithMany("CarModels")
                        .HasForeignKey("CarMakesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
