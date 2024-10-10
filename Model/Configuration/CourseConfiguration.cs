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
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CourseCode).HasDefaultValue(GenerateRandomString());
            builder.Property(x => x.CourseName).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(255);
            builder.Property(x => x.Duration).IsRequired();
            builder.Property(x => x.Fee).HasDefaultValue(0);
            builder.Property(x => x.Discount).HasDefaultValue(0);
            builder.Property(x => x.TotalFee).HasDefaultValue(0);
            builder.Property(x => x.IsActive).HasDefaultValue(true);
            builder.Property(x => x.CreatedDate).HasDefaultValue(DateTime.UtcNow);
            builder.Property(x => x.UpdatedDate).HasDefaultValue(DateTime.UtcNow);
            builder.HasOne(x => x.Level).WithMany(x => x.Course).HasForeignKey(x => x.LevelId);

            #region Seed Data
            builder.HasData(
                    // English Courses
                    new Course { Id = 1, CourseCode = "EN001", CourseName = "English for Beginners", Description = "Introduction to English for complete beginners.", Duration = "3 months", Fee = 3500000, Discount = 0.1, TotalFee = 3150000, IsActive = true, CreatedDate = new DateTime(2024, 1, 1), UpdatedDate = new DateTime(2024, 1, 10), LevelId = 1 },
                    new Course { Id = 2, CourseCode = "EN002", CourseName = "Elementary English", Description = "Basic English skills for elementary level.", Duration = "3 months", Fee = 4000000, Discount = 0.1, TotalFee = 3600000, IsActive = true, CreatedDate = new DateTime(2024, 2, 1), UpdatedDate = new DateTime(2024, 2, 10), LevelId = 2 },
                    new Course { Id = 3, CourseCode = "EN003", CourseName = "Intermediate English", Description = "Improve your English skills with intermediate level courses.", Duration = "4 months", Fee = 5000000, Discount = 0.15, TotalFee = 4250000, IsActive = true, CreatedDate = new DateTime(2024, 3, 1), UpdatedDate = new DateTime(2024, 3, 10), LevelId = 3 },
                    new Course { Id = 4, CourseCode = "EN004", CourseName = "Upper Intermediate English", Description = "Enhance your English proficiency at an upper intermediate level.", Duration = "5 months", Fee = 6500000, Discount = 0.2, TotalFee = 5200000, IsActive = true, CreatedDate = new DateTime(2024, 4, 1), UpdatedDate = new DateTime(2024, 4, 10), LevelId = 4 },
                    new Course { Id = 5, CourseCode = "EN005", CourseName = "Advanced English", Description = "Master advanced English skills with specialized courses.", Duration = "6 months", Fee = 8000000, Discount = 0.25, TotalFee = 6000000, IsActive = true, CreatedDate = new DateTime(2024, 5, 1), UpdatedDate = new DateTime(2024, 5, 10), LevelId = 5 },

                    // French Courses
                    new Course { Id = 6, CourseCode = "FR001", CourseName = "Débutant en Français", Description = "Introduction au français pour débutants.", Duration = "3 months", Fee = 3200000, Discount = 0.1, TotalFee = 2880000, IsActive = true, CreatedDate = new DateTime(2024, 6, 1), UpdatedDate = new DateTime(2024, 6, 10), LevelId = 6 },
                    new Course { Id = 7, CourseCode = "FR002", CourseName = "Français Élémentaire", Description = "Compétences de base en français à un niveau élémentaire.", Duration = "3 months", Fee = 3600000, Discount = 0.1, TotalFee = 3240000, IsActive = true, CreatedDate = new DateTime(2024, 7, 1), UpdatedDate = new DateTime(2024, 7, 10), LevelId = 7 },
                    new Course { Id = 8, CourseCode = "FR003", CourseName = "Français Intermédiaire", Description = "Améliorez vos compétences en français à un niveau intermédiaire.", Duration = "4 months", Fee = 4500000, Discount = 0.15, TotalFee = 3825000, IsActive = true, CreatedDate = new DateTime(2024, 8, 1), UpdatedDate = new DateTime(2024, 8, 10), LevelId = 8 },
                    new Course { Id = 9, CourseCode = "FR004", CourseName = "Français Supérieur", Description = "Perfectionnez votre français à un niveau supérieur.", Duration = "5 months", Fee = 5800000, Discount = 0.2, TotalFee = 4640000, IsActive = true, CreatedDate = new DateTime(2024, 9, 1), UpdatedDate = new DateTime(2024, 9, 10), LevelId = 9 },
                    new Course { Id = 10, CourseCode = "FR005", CourseName = "Français Avancé", Description = "Maîtrisez le français avec des cours avancés.", Duration = "6 months", Fee = 7200000, Discount = 0.25, TotalFee = 5400000, IsActive = true, CreatedDate = new DateTime(2024, 10, 1), UpdatedDate = new DateTime(2024, 10, 10), LevelId = 10 },

                    // Spanish Courses
                    new Course { Id = 11, CourseCode = "ES001", CourseName = "Principiante en Español", Description = "Introducción al español para principiantes.", Duration = "3 months", Fee = 3500000, Discount = 0.1, TotalFee = 3150000, IsActive = true, CreatedDate = new DateTime(2024, 11, 1), UpdatedDate = new DateTime(2024, 11, 10), LevelId = 11 },
                    new Course { Id = 12, CourseCode = "ES002", CourseName = "Español Elemental", Description = "Habilidades básicas en español a nivel elemental.", Duration = "3 months", Fee = 4000000, Discount = 0.1, TotalFee = 3600000, IsActive = true, CreatedDate = new DateTime(2024, 12, 1), UpdatedDate = new DateTime(2024, 12, 10), LevelId = 12 },
                    new Course { Id = 13, CourseCode = "ES003", CourseName = "Español Intermedio", Description = "Mejore sus habilidades en español con cursos intermedios.", Duration = "4 months", Fee = 5000000, Discount = 0.15, TotalFee = 4250000, IsActive = true, CreatedDate = new DateTime(2024, 1, 15), UpdatedDate = new DateTime(2024, 1, 20), LevelId = 13 },
                    new Course { Id = 14, CourseCode = "ES004", CourseName = "Español Avanzado", Description = "Perfeccione su español con cursos avanzados.", Duration = "5 months", Fee = 6500000, Discount = 0.2, TotalFee = 5200000, IsActive = true, CreatedDate = new DateTime(2024, 2, 15), UpdatedDate = new DateTime(2024, 2, 20), LevelId = 14 },
                    new Course { Id = 15, CourseCode = "ES005", CourseName = "Maestría en Español", Description = "Maestría en el uso del español con cursos de nivel superior.", Duration = "6 months", Fee = 8000000, Discount = 0.25, TotalFee = 6000000, IsActive = true, CreatedDate = new DateTime(2024, 3, 15), UpdatedDate = new DateTime(2024, 3, 20), LevelId = 15 },

                    // Chinese Courses
                    new Course { Id = 16, CourseCode = "ZH001", CourseName = "HSK 1 Chinese", Description = "Introduction to Chinese at HSK 1 level.", Duration = "3 months", Fee = 000000, Discount = 0.1, TotalFee = 2700000, IsActive = true, CreatedDate = new DateTime(2024, 4, 5), UpdatedDate = new DateTime(2024, 4, 10), LevelId = 16 },
                    new Course { Id = 17, CourseCode = "ZH002", CourseName = "HSK 2 Chinese", Description = "Chinese course at HSK 2 level.", Duration = "3 months", Fee = 3500000, Discount = 0.1, TotalFee = 3150000, IsActive = true, CreatedDate = new DateTime(2024, 5, 5), UpdatedDate = new DateTime(2024, 5, 10), LevelId = 17 },
                    new Course { Id = 18, CourseCode = "ZH003", CourseName = "HSK 3 Chinese", Description = "Intermediate Chinese course at HSK 3 level.", Duration = "4 months", Fee = 4500000, Discount = 0.15, TotalFee = 3825000, IsActive = true, CreatedDate = new DateTime(2024, 6, 5), UpdatedDate = new DateTime(2024, 6, 10), LevelId = 18 },
                    new Course { Id = 19, CourseCode = "ZH004", CourseName = "HSK 4 Chinese", Description = "Advanced Chinese course at HSK 4 level.", Duration = "5 months", Fee = 5800000, Discount = 0.2, TotalFee = 4640000, IsActive = true, CreatedDate = new DateTime(2024, 7, 5), UpdatedDate = new DateTime(2024, 7, 10), LevelId = 19 },
                    new Course { Id = 20, CourseCode = "ZH005", CourseName = "HSK 5 Chinese", Description = "Master Chinese skills at HSK 5 level.", Duration = "6 months", Fee = 7200000, Discount = 0.25, TotalFee = 5400000, IsActive = true, CreatedDate = new DateTime(2024, 8, 5), UpdatedDate = new DateTime(2024, 8, 10), LevelId = 20 }
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
