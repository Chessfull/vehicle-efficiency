using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleEfficiencyAcd.Data.Entities
{
    public class VehicleEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Plate { get; set; }
        public string? ImagePath { get; set; }
    }

    public class VehicleConfiguration : BaseConfiguration<VehicleEntity> // -> Calling base generic config I defined in baseentity schema
    {
        public override void Configure(EntityTypeBuilder<VehicleEntity> builder)
        {
            // ▼ Apply base configuration ( In my scenario I use this for soft delete processes )
            base.Configure(builder);

            // ▼ Additional configs except from BaseConfiguration ▼
            builder.Property(v => v.Name).IsRequired();
            builder.Property(v => v.Plate).IsRequired();

            // ▼ Adding Seed Data for my tests▼
            builder.HasData(
    new VehicleEntity { Id = 1, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, Name = "Ferrari", Plate = "26 ACD 999", ImagePath = "/images/vehicles/ferrari.jpg" },
    new VehicleEntity { Id = 2, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, Name = "Renault Clio", Plate = "26 DEF 200", ImagePath = "/images/vehicles/clio.jpg" },
    new VehicleEntity { Id = 3, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, Name = "Toyota Corolla", Plate = "34 ABC 101", ImagePath = "/images/vehicles/corolla.jpg" },
    new VehicleEntity { Id = 4, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, Name = "Honda Civic", Plate = "06 DEF 202", ImagePath = "/images/vehicles/civic.jpg" },
    new VehicleEntity { Id = 5, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, Name = "Ford Focus", Plate = "35 GHI 303", ImagePath = "/images/vehicles/focus.jpg" },
    new VehicleEntity { Id = 6, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, Name = "BMW 320i", Plate = "07 JKL 404", ImagePath = "/images/vehicles/bmw320i.jpg" },
    new VehicleEntity { Id = 7, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, Name = "Mercedes C200", Plate = "16 MNO 505", ImagePath = "/images/vehicles/mercedesc200.jpg" },
    new VehicleEntity { Id = 8, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, Name = "Audi A4", Plate = "10 PQR 606", ImagePath = "/images/vehicles/audia4.jpg" },
    new VehicleEntity { Id = 9, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, Name = "Volkswagen Golf", Plate = "20 STU 707", ImagePath = "/images/vehicles/golf.jpg" },
    new VehicleEntity { Id = 10, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, Name = "Nissan Altima", Plate = "26 ABC 808", ImagePath = "/images/vehicles/altima.jpg" },
    new VehicleEntity { Id = 11, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, Name = "Hyundai Elantra", Plate = "42 YZA 909", ImagePath = "/images/vehicles/elantra.jpg" },
    new VehicleEntity { Id = 12, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, Name = "Chevrolet Cruze", Plate = "27 BCD 111", ImagePath = "/images/vehicles/cruze.jpg" }

);
        }
    }
}
