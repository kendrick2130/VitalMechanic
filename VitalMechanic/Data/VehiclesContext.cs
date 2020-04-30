using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using VitalMechanic.Models;
using System.Linq;

namespace VitalMechanic.Data
{
    public partial class VehiclesContext : DbContext
    {
       
        public VehiclesContext()
        {
        }

        public VehiclesContext(DbContextOptions<VehiclesContext> options)
            : base(options)
        {  
        }       
        public virtual DbSet<CarMakes> CarMakes { get; set; }
        public virtual DbSet<CarGarage> CarGarage { get; set; }
        public virtual DbSet<CarMileageMilestone> CarMileageMilestone { get; set; }
        public virtual DbSet<CarModels> CarModels { get; set; }
        public virtual DbSet<CarYear> CarYear { get; set; }
        public virtual DbSet<MileageMilestone> MileageMilestone { get; set; }
        public virtual DbSet<UserCars> UserCars { get; set; }
        public virtual DbSet<UserloginTbl> UserloginTbl { get; set; }
        public virtual DbSet<EngineSize> EngineSizes { get; set; }
        public virtual DbSet<DriveTran> DriveTrans { get; set; }
        public virtual DbSet<Transmission> Transmissions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=KING_K\\SQLEXPRESS;Database=VehicleContext;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarMakes>(entity =>
            {
                entity.HasKey(e => e.MakeId);

                entity.ToTable("CarMake");

                entity.Property(e => e.MakeId)
                    .HasColumnName("make_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Make)
                    .IsRequired()
                    .HasColumnName("make")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CarMileageMilestone>(entity =>
            {
                entity.HasKey(e => e.UserCarId)
                    .HasName("PK__Car_Mile__C4DBA719B5E39FDC");

                entity.ToTable("Car_Mileage_Milestone");

                entity.Property(e => e.UserCarId)
                    .HasColumnName("UserCarID")
                    .ValueGeneratedNever();

                entity.Property(e => e.MaintenanceCompletionDate)
                    .HasColumnName("maintenance_completion_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Mileageid).HasColumnName("mileageid");

                entity.HasOne(d => d.Mileage)
                    .WithMany(p => p.CarMileageMilestone)
                    .HasForeignKey(d => d.Mileageid)
                    .HasConstraintName("FK__Car_Milea__milea__5441852A");
            });

            modelBuilder.Entity<CarModels>(entity =>
            {
                entity.HasKey(e => e.ModelId)
                    .HasName("PK__car_mode__DC39CAF45A225732");

                entity.ToTable("CarModels");

                entity.Property(e => e.ModelId)
                    .HasColumnName("model_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.MakeId)
                .HasColumnName("make_id");

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasColumnName("model")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Make)
                    .WithMany(p => p.CarModels)
                    .HasForeignKey(d => d.MakeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__car_model__make___4F7CD00D");
            });

            modelBuilder.Entity<CarYear>(entity =>
            {
                entity.HasKey(e => e.YearMakeId)
                    .HasName("PK__Car_Year__BEACAE6A137E5E8F");

                entity.ToTable("CarYear");

                entity.Property(e => e.YearMakeId)
                    .HasColumnName("YearMakeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.YearOfMake).HasColumnName("YearOfMake");
            });

            modelBuilder.Entity<CarGarage>(entity =>
            {
                entity.HasKey(e => e.CarGarageID);

                entity.ToTable("CarGarage");

                entity.Property(e => e.CarGarageID)
                    .HasColumnName("CarGarageID")
                    .ValueGeneratedNever();
                
                entity.Property(e => e.CarYear)
                .IsRequired()
                .HasColumnName("Year")
                .HasMaxLength(255)
                .IsUnicode(false);

                entity.Property(e => e.CarMake)
                    .IsRequired()
                    .HasColumnName("Make")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CarModels)
                    .IsRequired()
                    .HasColumnName("Model")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DriveTran)
                    .IsRequired()
                    .HasColumnName("DriveTran")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EngineSize)
                    .IsRequired()
                    .HasColumnName("EngineSize")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Transmission)
                    .IsRequired()
                    .HasColumnName("Transmission")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MileageMilestone>(entity =>
            {
                entity.HasKey(e => e.Mileageid)
                    .HasName("PK__Mileage___F745D1F867E5B87D");

                entity.ToTable("Mileage_Milestone");

                entity.Property(e => e.Mileageid)
                    .HasColumnName("mileageid")
                    .ValueGeneratedNever();

                entity.Property(e => e.CarMileage).HasColumnName("car_mileage");

                entity.Property(e => e.Milestones).HasColumnName("milestones");
            });

            modelBuilder.Entity<UserCars>(entity =>
            {
                entity.HasKey(e => e.UserCarId);

                entity.Property(e => e.UserCarId)
                    .HasColumnName("UserCarID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ModelId)
                .HasColumnName("model_id");

                entity.Property(e => e.UserId)
                .HasColumnName("UserID");

                entity.Property(e => e.YearMakeId)
                .HasColumnName("YearMakeID");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.UserCars)
                    .HasForeignKey(d => d.ModelId)
                    .HasConstraintName("FK__UserCars__model___628FA481");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserCars)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__UserCars__UserID__619B8048");

                entity.HasOne(d => d.YearMake)
                    .WithMany(p => p.UserCars)
                    .HasForeignKey(d => d.YearMakeId)
                    .HasConstraintName("FK__UserCars__YearMa__6383C8BA");
            });

            modelBuilder.Entity<UserloginTbl>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.EmailAddress)
                    .HasColumnName("Email_Address")
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .HasColumnName("First_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .HasColumnName("Last_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(20);

                entity.Property(e => e.Username).HasMaxLength(20);
            });

            modelBuilder.Entity<EngineSize>(entity =>
            {
                entity.HasKey(e => e.EngineID);

                entity.ToTable("EngineSize");

                entity.Property(e => e.EngineID)
                    .HasColumnName("EngineID")
                    .ValueGeneratedNever();

                entity.Property(e => e.EngineType)
                    .IsRequired()
                    .HasColumnName("EngineType")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DriveTran>(entity =>
            {
                entity.HasKey(e => e.DriveTranID);

                entity.ToTable("DriveTran");

                entity.Property(e => e.DriveTranID)
                    .HasColumnName("DriveTranID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DriveTranType)
                    .IsRequired()
                    .HasColumnName("DriveTranType")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Transmission>(entity =>
            {
                entity.HasKey(e => e.TransmissionID);

                entity.ToTable("Transmission");

                entity.Property(e => e.TransmissionID)
                    .HasColumnName("TransmissionID")
                    .ValueGeneratedNever();

                entity.Property(e => e.TransmissionType)
                    .IsRequired()
                    .HasColumnName("TransmissionType")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
