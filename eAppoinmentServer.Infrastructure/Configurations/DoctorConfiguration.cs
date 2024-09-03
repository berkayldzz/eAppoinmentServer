using eAppoinmentServer.Domain.Entities;
using eAppoinmentServer.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAppoinmentServer.Infrastructure.Configurations
{
    // Doctor entity type ait veritabanında nasıl yapılandırılacağını gösteren sınıfım.
    internal sealed class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.Property(p => p.FirstName).HasColumnType("varchar(50)");
            builder.Property(p => p.LastName).HasColumnType("varchar(50)");
            //builder.HasIndex(x => new { x.FirstName, x.LastName }).IsUnique();

            builder.Property(p => p.Department)
                .HasConversion(v => v.Value, v => DepartmentEnum.FromValue(v))
                .HasColumnName("Department");
        }
    }
}
