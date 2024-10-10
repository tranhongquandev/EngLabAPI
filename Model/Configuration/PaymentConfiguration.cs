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
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.PaymentCode).HasMaxLength(20).HasDefaultValue(GenerateRandomString());
            builder.Property(x => x.PaymentDate).HasDefaultValue(DateTime.UtcNow);
            builder.Property(x => x.PaymentStatus).HasMaxLength(20).HasDefaultValue("Created");
            builder.Property(x => x.Amount).HasDefaultValue(0);
            builder.HasOne(x => x.PaymentMethod).WithMany(x => x.Payment).HasForeignKey(x => x.PaymentMethodId);
            builder.HasOne(x => x.Student).WithMany(x => x.Payment).HasForeignKey(x => x.StudentId);
            builder.HasOne(x => x.Course).WithMany(x => x.Payment).HasForeignKey(x => x.CourseId);
        }

        #region Seed Data

        #endregion

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
