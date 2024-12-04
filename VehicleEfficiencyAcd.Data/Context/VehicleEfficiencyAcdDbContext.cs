using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleEfficiencyAcd.Data.Entities;

namespace VehicleEfficiencyAcd.Data.Context
{
    public class VehicleEfficiencyAcdDbContext : DbContext
    {

        // ▼ Sending DbContext constructor to project dbcontext with base(options) ▼
        public VehicleEfficiencyAcdDbContext(DbContextOptions<VehicleEfficiencyAcdDbContext> options) : base(options)
        {

        }

        // ▼ I created this for ignore config error for initial ▼
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings =>
                warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }

        // ▼ Defining Tables ▼
        public DbSet<VehicleEntity> Vehicles => Set<VehicleEntity>();
        public DbSet<VehicleUsageEntity> VehicleUsages => Set<VehicleUsageEntity>();
        public DbSet<UserEntity> Users => Set<UserEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ▼ Applying config I sets as modular on entities ▼
            modelBuilder.ApplyConfiguration(new VehicleConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleUsageConfiguration());

            base.OnModelCreating(modelBuilder);
        }

    }
}
