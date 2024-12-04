using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleEfficiencyAcd.Data.Enums;

namespace VehicleEfficiencyAcd.Data.Entities
{
    public class UserEntity:BaseEntity
    {
        public string Email { get; set; } // -> also username in my scenario
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}"; // Setting full name from firstname and lastname
        public UserRole UserRole { get; set; } = UserRole.User;
    }

    public class UserConfiguration : BaseConfiguration<UserEntity> // -> Calling base generic config I defined in baseentity schema
    {
        public override void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            // ▼ Base config ▼
            base.Configure(builder);

            // ▼ Additional configs except from BaseConfiguration ▼
            builder.Property(p => p.Email).IsRequired();
            builder.Property(p => p.Password).IsRequired();
            builder.Property(p => p.FirstName).IsRequired();
            builder.Property(p => p.LastName).IsRequired();

        }
    }
}
