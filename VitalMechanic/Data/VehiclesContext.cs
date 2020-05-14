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
        public virtual DbSet<CarModels> CarModels { get; set; }
        public virtual DbSet<CarYear> CarYear { get; set; }          
        public virtual DbSet<EngineSize> EngineSizes { get; set; }
        public virtual DbSet<DriveTran> DriveTrans { get; set; }
        public virtual DbSet<Transmission> Transmissions { get; set; }
        public virtual DbSet<VehicleMiles> VehicleMiles { get; set; }
        public virtual DbSet<MileStones> VehicleMileStones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=KING_K\\SQLEXPRESS;Database=VehicleContext;Trusted_Connection=True;");
            }
        }
    }
}
