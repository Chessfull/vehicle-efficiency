using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleEfficiencyAcd.Data.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsDeleted { get; set; } // -> For soft delete processes I will manage with repository
    }

    // ▼ Base configs for databases, common fluent apis with generic way I defined, I will call this  ▼
    public abstract class BaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        // ▼ Base configurations for all derived classes in my scenario vehicle and usage ▼
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasQueryFilter(q => q.IsDeleted == false); // -> For using this filter on all database queries soft delete check with common way
        }

    }
}
