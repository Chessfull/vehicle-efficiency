using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleEfficiencyAcd.Data.Entities
{
    public class VehicleUsageEntity : BaseEntity
    {
        public int VehicleId { get; set; } // -> Foreign key for Vehicle
        public VehicleEntity Vehicle { get; set; } // -> Navigation property that I will use
        public double ActiveHours { get; set; }
        public double MaintenanceHours { get; set; }
        public string Week { get; set; } // -> In my scenario data builds according to iso week numbers like W1, W2 ....
    }

    public class VehicleUsageConfiguration : BaseConfiguration<VehicleUsageEntity> // -> Calling base generic config I defined in baseentity schema
    {
        // ▼ Apply base configuration ( In my scenario I use this for soft delete processes )
        public override void Configure(EntityTypeBuilder<VehicleUsageEntity> builder)
        {
            base.Configure(builder);

            // ▼ Configue relation
            builder.HasOne(vu => vu.Vehicle)
                .WithMany().HasForeignKey(vu => vu.VehicleId);

            // ▼ Additional configs except from BaseConfiguration ▼
            builder.Property(vu => vu.ActiveHours).IsRequired();
            builder.Property(vu => vu.MaintenanceHours).IsRequired();
            builder.Property(vu => vu.Week).IsRequired();
            builder.Property(vu => vu.VehicleId).IsRequired();

            // ▼ Adding Seed Data for my tests ▼
            builder.HasData(
                    // Vehicle 1
                    new VehicleUsageEntity { Id = 1, VehicleId = 1, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ActiveHours = 102, MaintenanceHours = 12, Week = "W1" },
                    new VehicleUsageEntity { Id = 2, VehicleId = 1, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ActiveHours = 150, MaintenanceHours = 8, Week = "W2" },
                    new VehicleUsageEntity { Id = 3, VehicleId = 1, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ActiveHours = 130, MaintenanceHours = 3, Week = "W3" },
                    new VehicleUsageEntity { Id = 4, VehicleId = 1, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ActiveHours = 160, MaintenanceHours = 7, Week = "W4" },
                    new VehicleUsageEntity { Id = 5, VehicleId = 1, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ActiveHours = 125, MaintenanceHours = 5, Week = "W5" },

                    // Vehicle 2
                    new VehicleUsageEntity { Id = 6, VehicleId = 2, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ActiveHours = 110, MaintenanceHours = 10, Week = "W1" },
                    new VehicleUsageEntity { Id = 7, VehicleId = 2, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ActiveHours = 140, MaintenanceHours = 6, Week = "W2" },
                    new VehicleUsageEntity { Id = 8, VehicleId = 2, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ActiveHours = 168, MaintenanceHours = 1, Week = "W3" },
                    new VehicleUsageEntity { Id = 9, VehicleId = 2, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ActiveHours = 155, MaintenanceHours = 4, Week = "W4" },
                    new VehicleUsageEntity { Id = 10, VehicleId = 2, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ActiveHours = 120, MaintenanceHours = 9, Week = "W5" },

                    // Vehicle 3
                    new VehicleUsageEntity { Id = 11, VehicleId = 3, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ActiveHours = 105, MaintenanceHours = 11, Week = "W1" },
                    new VehicleUsageEntity { Id = 12, VehicleId = 3, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ActiveHours = 140, MaintenanceHours = 2, Week = "W2" },
                    new VehicleUsageEntity { Id = 13, VehicleId = 3, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ActiveHours = 150, MaintenanceHours = 5, Week = "W3" },
                    new VehicleUsageEntity { Id = 14, VehicleId = 3, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ActiveHours = 135, MaintenanceHours = 8, Week = "W4" },
                    new VehicleUsageEntity { Id = 15, VehicleId = 3, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ActiveHours = 125, MaintenanceHours = 7, Week = "W5" },

                    // Vehicle 4
                    new VehicleUsageEntity { Id = 16, VehicleId = 4, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ActiveHours = 115, MaintenanceHours = 12, Week = "W1" },
                    new VehicleUsageEntity { Id = 17, VehicleId = 4, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ActiveHours = 145, MaintenanceHours = 9, Week = "W2" },
                    new VehicleUsageEntity { Id = 18, VehicleId = 4, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ActiveHours = 130, MaintenanceHours = 6, Week = "W3" },
                    new VehicleUsageEntity { Id = 19, VehicleId = 4, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ActiveHours = 140, MaintenanceHours = 3, Week = "W4" },
                    new VehicleUsageEntity { Id = 20, VehicleId = 4, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ActiveHours = 125, MaintenanceHours = 5, Week = "W5" },

                    // Vehicle 5
                    new VehicleUsageEntity { Id = 21, VehicleId = 5, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ActiveHours = 120, MaintenanceHours = 10, Week = "W1" },
                    new VehicleUsageEntity { Id = 22, VehicleId = 5, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ActiveHours = 140, MaintenanceHours = 7, Week = "W2" },
                    new VehicleUsageEntity { Id = 23, VehicleId = 5, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ActiveHours = 155, MaintenanceHours = 4, Week = "W3" },
                    new VehicleUsageEntity { Id = 24, VehicleId = 5, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ActiveHours = 135, MaintenanceHours = 6, Week = "W4" },
                    new VehicleUsageEntity { Id = 25, VehicleId = 5, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ActiveHours = 155, MaintenanceHours = 2, Week = "W5" },

                    // Vehicle 6
                    new VehicleUsageEntity { Id = 26, VehicleId = 6, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ActiveHours = 105, MaintenanceHours = 13, Week = "W1" },
                    new VehicleUsageEntity { Id = 27, VehicleId = 6, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ActiveHours = 150, MaintenanceHours = 5, Week = "W2" },
                    new VehicleUsageEntity { Id = 28, VehicleId = 6, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ActiveHours = 140, MaintenanceHours = 4, Week = "W3" },
                    new VehicleUsageEntity { Id = 29, VehicleId = 6, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ActiveHours = 135, MaintenanceHours = 9, Week = "W4" },
                    new VehicleUsageEntity { Id = 30, VehicleId = 6, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ActiveHours = 125, MaintenanceHours = 7, Week = "W5" },

                    // Vehicle 7
                    new VehicleUsageEntity { Id = 31, VehicleId = 7, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ActiveHours = 120, MaintenanceHours = 11, Week = "W1" },
                    new VehicleUsageEntity { Id = 32, VehicleId = 7, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ActiveHours = 155, MaintenanceHours = 3, Week = "W2" },
                    new VehicleUsageEntity { Id = 33, VehicleId = 7, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ActiveHours = 145, MaintenanceHours = 5, Week = "W3" },
                    new VehicleUsageEntity { Id = 34, VehicleId = 7, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ActiveHours = 140, MaintenanceHours = 8, Week = "W4" },
                    new VehicleUsageEntity { Id = 35, VehicleId = 7, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ActiveHours = 125, MaintenanceHours = 6, Week = "W5" },

                    // Vehicle 8
                    new VehicleUsageEntity { Id = 36, VehicleId = 8, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ActiveHours = 130, MaintenanceHours = 10, Week = "W1" },
                    new VehicleUsageEntity { Id = 37, VehicleId = 8, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ActiveHours = 155, MaintenanceHours = 4, Week = "W2" },
                    new VehicleUsageEntity { Id = 38, VehicleId = 8, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ActiveHours = 140, MaintenanceHours = 7, Week = "W3" },
                    new VehicleUsageEntity { Id = 39, VehicleId = 8, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ActiveHours = 150, MaintenanceHours = 6, Week = "W4" },
                    new VehicleUsageEntity { Id = 40, VehicleId = 8, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ActiveHours = 135, MaintenanceHours = 8, Week = "W5" },

                    // Vehicle 9
                    new VehicleUsageEntity { Id = 41, VehicleId = 9, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ActiveHours = 120, MaintenanceHours = 11, Week = "W1" },
                    new VehicleUsageEntity { Id = 42, VehicleId = 9, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ActiveHours = 140, MaintenanceHours = 3, Week = "W2" },
                    new VehicleUsageEntity { Id = 43, VehicleId = 9, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ActiveHours = 145, MaintenanceHours = 5, Week = "W3" },
                    new VehicleUsageEntity { Id = 44, VehicleId = 9, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ActiveHours = 140, MaintenanceHours = 8, Week = "W4" },
                    new VehicleUsageEntity { Id = 45, VehicleId = 9, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ActiveHours = 125, MaintenanceHours = 6, Week = "W5" },

                    // Vehicle 10
                    new VehicleUsageEntity { Id = 46, VehicleId = 10, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ActiveHours = 130, MaintenanceHours = 7, Week = "W1" },
                    new VehicleUsageEntity { Id = 47, VehicleId = 10, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ActiveHours = 140, MaintenanceHours = 1, Week = "W2" },
                    new VehicleUsageEntity { Id = 48, VehicleId = 10, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ActiveHours = 150, MaintenanceHours = 5, Week = "W3" },
                    new VehicleUsageEntity { Id = 49, VehicleId = 10, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ActiveHours = 140, MaintenanceHours = 6, Week = "W4" },
                    new VehicleUsageEntity { Id = 50, VehicleId = 10, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ActiveHours = 135, MaintenanceHours = 8, Week = "W5" },

                    // Vehicle 11
                    new VehicleUsageEntity { Id = 51, VehicleId = 11, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ActiveHours = 105, MaintenanceHours = 13, Week = "W1" },
                    new VehicleUsageEntity { Id = 52, VehicleId = 11, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ActiveHours = 140, MaintenanceHours = 3, Week = "W2" },
                    new VehicleUsageEntity { Id = 53, VehicleId = 11, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ActiveHours = 140, MaintenanceHours = 4, Week = "W3" },
                    new VehicleUsageEntity { Id = 54, VehicleId = 11, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ActiveHours = 130, MaintenanceHours = 6, Week = "W4" },
                    new VehicleUsageEntity { Id = 55, VehicleId = 11, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ActiveHours = 125, MaintenanceHours = 7, Week = "W5" },

                    // Vehicle 12
                    new VehicleUsageEntity { Id = 56, VehicleId = 12, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ActiveHours = 120, MaintenanceHours = 10, Week = "W1" },
                    new VehicleUsageEntity { Id = 57, VehicleId = 12, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ActiveHours = 145, MaintenanceHours = 9, Week = "W2" },
                    new VehicleUsageEntity { Id = 58, VehicleId = 12, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ActiveHours = 130, MaintenanceHours = 6, Week = "W3" },
                    new VehicleUsageEntity { Id = 59, VehicleId = 12, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ActiveHours = 150, MaintenanceHours = 5, Week = "W4" },
                    new VehicleUsageEntity { Id = 60, VehicleId = 12, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ActiveHours = 135, MaintenanceHours = 7, Week = "W5" }
                    );
        }
    }

}
