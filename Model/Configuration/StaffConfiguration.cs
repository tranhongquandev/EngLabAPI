using EngLabAPI.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngLabAPI.Model.Configurations
{
    public class StaffConfiguration : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.StaffCode).HasMaxLength(50).HasDefaultValue(GenerateRandomString());
            builder.Property(x => x.ImgUrl).HasMaxLength(255);
            builder.Property(x => x.FullName).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Gender).HasMaxLength(20).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(50).IsRequired();
            builder.Property(x => x.PasswordHash).HasMaxLength(255).IsRequired();
            builder.Property(x => x.PhoneNumber).HasMaxLength(20).IsRequired();
            builder.Property(x => x.Address).HasMaxLength(255);
            builder.Property(x => x.DateOfBirth);
            builder.Property(x => x.HireDate).HasDefaultValue(DateTime.UtcNow);
            builder.Property(x => x.EndDate);
            builder.Property(x => x.IsActive).HasDefaultValue(true);
            builder.HasOne(x => x.StaffRoles).WithMany(x => x.Staffs).HasForeignKey(x => x.RoleId);

            #region Seed Data
            builder.HasData(
                new Staff { Id = 1, FullName = "Quản trị viên", Gender = "Nam", Email = "tranhongquan.dev@gmail.com", PasswordHash = "$2a$11$mVOzIRFb71alNYrUvBcknOhWMJnnebsW4EDRz7/pjjBTiF0s9u4Ci", PhoneNumber = "123456789", Address = "123 đường ABC, Hà Nội, VN", DateOfBirth = new DateTime(2003, 04, 28), HireDate = new DateTime(2024, 09, 12), IsActive = true, RoleId = 1 }
            );
            #endregion

        }

        // Generate random string function
        static string GenerateRandomString()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            int length = 6;
            StringBuilder result = new StringBuilder(length);
            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                result.Append(chars[random.Next(chars.Length)]);
            }

            return result.ToString();
        }
    }
}
