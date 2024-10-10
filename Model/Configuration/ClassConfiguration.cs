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
    public class ClassConfiguration : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ClassCode).HasDefaultValue(GenerateRandomString());
            builder.Property(x => x.ClassName).IsRequired();
            builder.Property(x => x.StartDate);
            builder.Property(x => x.EndDate);
            builder.HasOne(x => x.Course).WithMany(x => x.Class).HasForeignKey(x => x.CourseId);
            builder.HasOne(x => x.Teacher).WithMany(x => x.Class).HasForeignKey(x => x.TeacherId);

            #region Seed Data
            builder.HasData(
                new Class { Id = 1, ClassCode = "C001", ClassName = "English Beginner A", StartDate = new DateTime(2024, 1, 10), EndDate = new DateTime(2024, 4, 10), CourseId = 1, TeacherId = 1 },
                new Class { Id = 2, ClassCode = "C002", ClassName = "English Beginner B", StartDate = new DateTime(2024, 2, 10), EndDate = new DateTime(2024, 5, 10), CourseId = 2, TeacherId = 2 },
                new Class { Id = 3, ClassCode = "C003", ClassName = "English Intermediate A", StartDate = new DateTime(2024, 3, 10), EndDate = new DateTime(2024, 6, 10), CourseId = 3, TeacherId = 3 },
                new Class { Id = 4, ClassCode = "C004", ClassName = "English Upper Intermediate A", StartDate = new DateTime(2024, 4, 10), EndDate = new DateTime(2024, 7, 10), CourseId = 4, TeacherId = 4 },
                new Class { Id = 5, ClassCode = "C005", ClassName = "English Advanced A", StartDate = new DateTime(2024, 5, 10), EndDate = new DateTime(2024, 8, 10), CourseId = 5, TeacherId = 5 },

                // Class 6 - 10 for Courses 6-10
                new Class { Id = 6, ClassCode = "C006", ClassName = "French Beginner A", StartDate = new DateTime(2024, 6, 10), EndDate = new DateTime(2024, 9, 10), CourseId = 6, TeacherId = 6 },
                new Class { Id = 7, ClassCode = "C007", ClassName = "French Beginner B", StartDate = new DateTime(2024, 7, 10), EndDate = new DateTime(2024, 10, 10), CourseId = 7, TeacherId = 7 },
                new Class { Id = 8, ClassCode = "C008", ClassName = "French Intermediate A", StartDate = new DateTime(2024, 8, 10), EndDate = new DateTime(2024, 11, 10), CourseId = 8, TeacherId = 8 },
                new Class { Id = 9, ClassCode = "C009", ClassName = "French Upper Intermediate A", StartDate = new DateTime(2024, 9, 10), EndDate = new DateTime(2024, 12, 10), CourseId = 9, TeacherId = 9 },
                new Class { Id = 10, ClassCode = "C010", ClassName = "French Advanced A", StartDate = new DateTime(2024, 10, 10), EndDate = new DateTime(2025, 1, 10), CourseId = 10, TeacherId = 10 },

                // Class 11 - 15 for Courses 11-15
                new Class { Id = 11, ClassCode = "C011", ClassName = "Spanish Beginner A", StartDate = new DateTime(2024, 11, 10), EndDate = new DateTime(2025, 2, 10), CourseId = 11, TeacherId = 1 },
                new Class { Id = 12, ClassCode = "C012", ClassName = "Spanish Beginner B", StartDate = new DateTime(2024, 12, 10), EndDate = new DateTime(2025, 3, 10), CourseId = 12, TeacherId = 2 },
                new Class { Id = 13, ClassCode = "C013", ClassName = "Spanish Intermediate A", StartDate = new DateTime(2025, 1, 10), EndDate = new DateTime(2025, 4, 10), CourseId = 13, TeacherId = 3 },
                new Class { Id = 14, ClassCode = "C014", ClassName = "Spanish Upper Intermediate A", StartDate = new DateTime(2025, 2, 10), EndDate = new DateTime(2025, 5, 10), CourseId = 14, TeacherId = 4 },
                new Class { Id = 15, ClassCode = "C015", ClassName = "Spanish Advanced A", StartDate = new DateTime(2025, 3, 10), EndDate = new DateTime(2025, 6, 10), CourseId = 15, TeacherId = 5 },

                // Class 16 - 20 for Courses 16-20
                new Class { Id = 16, ClassCode = "C016", ClassName = "Chinese HSK 1 A", StartDate = new DateTime(2025, 4, 10), EndDate = new DateTime(2025, 7, 10), CourseId = 16, TeacherId = 6 },
                new Class { Id = 17, ClassCode = "C017", ClassName = "Chinese HSK 2 A", StartDate = new DateTime(2025, 5, 10), EndDate = new DateTime(2025, 8, 10), CourseId = 17, TeacherId = 7 },
                new Class { Id = 18, ClassCode = "C018", ClassName = "Chinese HSK 3 A", StartDate = new DateTime(2025, 6, 10), EndDate = new DateTime(2025, 9, 10), CourseId = 18, TeacherId = 8 },
                new Class { Id = 19, ClassCode = "C019", ClassName = "Chinese HSK 4 A", StartDate = new DateTime(2025, 7, 10), EndDate = new DateTime(2025, 10, 10), CourseId = 19, TeacherId = 9 },
                new Class { Id = 20, ClassCode = "C020", ClassName = "Chinese HSK 5 A", StartDate = new DateTime(2025, 8, 10), EndDate = new DateTime(2025, 11, 10), CourseId = 20, TeacherId = 10 }
                );
            #endregion
        }

        //Generate random string function
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
