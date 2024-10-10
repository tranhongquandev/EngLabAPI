using EngLabAPI.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngLabAPI.Model.Configurations
{
    public class StaffRoleConfiguration : IEntityTypeConfiguration<StaffRole>
    {
        public void Configure(EntityTypeBuilder<StaffRole> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.RoleName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Rank).IsRequired();


            #region Seed Data
            builder.HasData(
                new StaffRole { Id = 1, RoleName = "Admin", Rank = 1 },
                new StaffRole { Id = 2, RoleName = "Center Manager", Rank = 2 },
                new StaffRole { Id = 3, RoleName = "Student Coordinator", Rank = 3 },
                new StaffRole { Id = 4, RoleName = "HR Manager", Rank = 3 }
                );
            #endregion
        }
    }
}
