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
    public class ClassStudentConfiguration : IEntityTypeConfiguration<ClassStudent>
    {
        public void Configure(EntityTypeBuilder<ClassStudent> builder)
        {
            builder.HasKey(x => new { x.StudentId, x.ClassId });
            builder.HasOne(x => x.Student).WithMany(x => x.ClassStudent).HasForeignKey(x => x.StudentId);
            builder.HasOne(x => x.Class).WithMany(x => x.ClassStudent).HasForeignKey(x => x.ClassId);

            #region Seed Data
            builder.HasData(
                // Class 1
                new ClassStudent { ClassId = 1, StudentId = 1 },
                new ClassStudent { ClassId = 1, StudentId = 2 },
                new ClassStudent { ClassId = 1, StudentId = 3 },
                new ClassStudent { ClassId = 1, StudentId = 4 },
                new ClassStudent { ClassId = 1, StudentId = 5 },
                new ClassStudent { ClassId = 1, StudentId = 6 },
                new ClassStudent { ClassId = 1, StudentId = 7 },
                new ClassStudent { ClassId = 1, StudentId = 8 },
                new ClassStudent { ClassId = 1, StudentId = 9 },
                new ClassStudent { ClassId = 1, StudentId = 10 },
                new ClassStudent { ClassId = 1, StudentId = 11 },
                new ClassStudent { ClassId = 1, StudentId = 12 },
                new ClassStudent { ClassId = 1, StudentId = 13 },
                new ClassStudent { ClassId = 1, StudentId = 14 },
                new ClassStudent { ClassId = 1, StudentId = 15 },

                // Class 2
                new ClassStudent { ClassId = 2, StudentId = 16 },
                new ClassStudent { ClassId = 2, StudentId = 17 },
                new ClassStudent { ClassId = 2, StudentId = 18 },
                new ClassStudent { ClassId = 2, StudentId = 19 },
                new ClassStudent { ClassId = 2, StudentId = 20 },
                new ClassStudent { ClassId = 2, StudentId = 21 },
                new ClassStudent { ClassId = 2, StudentId = 22 },
                new ClassStudent { ClassId = 2, StudentId = 23 },
                new ClassStudent { ClassId = 2, StudentId = 24 },
                new ClassStudent { ClassId = 2, StudentId = 25 },
                new ClassStudent { ClassId = 2, StudentId = 1 },
                new ClassStudent { ClassId = 2, StudentId = 2 },
                new ClassStudent { ClassId = 2, StudentId = 3 },
                new ClassStudent { ClassId = 2, StudentId = 4 },

                // Class 3
                new ClassStudent { ClassId = 3, StudentId = 5 },
                new ClassStudent { ClassId = 3, StudentId = 6 },
                new ClassStudent { ClassId = 3, StudentId = 7 },
                new ClassStudent { ClassId = 3, StudentId = 8 },
                new ClassStudent { ClassId = 3, StudentId = 9 },
                new ClassStudent { ClassId = 3, StudentId = 10 },
                new ClassStudent { ClassId = 3, StudentId = 11 },
                new ClassStudent { ClassId = 3, StudentId = 12 },
                new ClassStudent { ClassId = 3, StudentId = 13 },
                new ClassStudent { ClassId = 3, StudentId = 14 },
                new ClassStudent { ClassId = 3, StudentId = 15 },
                new ClassStudent { ClassId = 3, StudentId = 16 },
                new ClassStudent { ClassId = 3, StudentId = 17 },
                new ClassStudent { ClassId = 3, StudentId = 18 },

                // Class 4
                new ClassStudent { ClassId = 4, StudentId = 19 },
                new ClassStudent { ClassId = 4, StudentId = 20 },
                new ClassStudent { ClassId = 4, StudentId = 21 },
                new ClassStudent { ClassId = 4, StudentId = 22 },
                new ClassStudent { ClassId = 4, StudentId = 23 },
                new ClassStudent { ClassId = 4, StudentId = 24 },
                new ClassStudent { ClassId = 4, StudentId = 25 },
                new ClassStudent { ClassId = 4, StudentId = 26 },
                new ClassStudent { ClassId = 4, StudentId = 27 },
                new ClassStudent { ClassId = 4, StudentId = 28 },
                new ClassStudent { ClassId = 4, StudentId = 29 },
                new ClassStudent { ClassId = 4, StudentId = 30 },
                new ClassStudent { ClassId = 4, StudentId = 31 },
                new ClassStudent { ClassId = 4, StudentId = 32 },

                // Class 5
                new ClassStudent { ClassId = 5, StudentId = 33 },
                new ClassStudent { ClassId = 5, StudentId = 34 },
                new ClassStudent { ClassId = 5, StudentId = 35 },
                new ClassStudent { ClassId = 5, StudentId = 36 },
                new ClassStudent { ClassId = 5, StudentId = 37 },
                new ClassStudent { ClassId = 5, StudentId = 38 },
                new ClassStudent { ClassId = 5, StudentId = 39 },
                new ClassStudent { ClassId = 5, StudentId = 40 },
                new ClassStudent { ClassId = 5, StudentId = 41 },
                new ClassStudent { ClassId = 5, StudentId = 42 },
                new ClassStudent { ClassId = 5, StudentId = 43 },
                new ClassStudent { ClassId = 5, StudentId = 44 },
                new ClassStudent { ClassId = 5, StudentId = 45 },
                new ClassStudent { ClassId = 5, StudentId = 46 },

                // Class 6
                new ClassStudent { ClassId = 6, StudentId = 47 },
                new ClassStudent { ClassId = 6, StudentId = 48 },
                new ClassStudent { ClassId = 6, StudentId = 49 },
                new ClassStudent { ClassId = 6, StudentId = 50 },
                new ClassStudent { ClassId = 6, StudentId = 1 },
                new ClassStudent { ClassId = 6, StudentId = 2 },
                new ClassStudent { ClassId = 6, StudentId = 3 },
                new ClassStudent { ClassId = 6, StudentId = 4 },
                new ClassStudent { ClassId = 6, StudentId = 5 },
                new ClassStudent { ClassId = 6, StudentId = 6 },
                new ClassStudent { ClassId = 6, StudentId = 7 },
                new ClassStudent { ClassId = 6, StudentId = 8 },
                new ClassStudent { ClassId = 6, StudentId = 9 },
                new ClassStudent { ClassId = 6, StudentId = 10 },

                // Class 7
                new ClassStudent { ClassId = 7, StudentId = 11 },
                new ClassStudent { ClassId = 7, StudentId = 12 },
                new ClassStudent { ClassId = 7, StudentId = 13 },
                new ClassStudent { ClassId = 7, StudentId = 14 },
                new ClassStudent { ClassId = 7, StudentId = 15 },
                new ClassStudent { ClassId = 7, StudentId = 16 },
                new ClassStudent { ClassId = 7, StudentId = 17 },
                new ClassStudent { ClassId = 7, StudentId = 18 },
                new ClassStudent { ClassId = 7, StudentId = 19 },
                new ClassStudent { ClassId = 7, StudentId = 20 },
                new ClassStudent { ClassId = 7, StudentId = 21 },
                new ClassStudent { ClassId = 7, StudentId = 22 },
                new ClassStudent { ClassId = 7, StudentId = 23 },
                new ClassStudent { ClassId = 7, StudentId = 24 },

                // Class 8
                new ClassStudent { ClassId = 8, StudentId = 25 },
                new ClassStudent { ClassId = 8, StudentId = 26 },
                new ClassStudent { ClassId = 8, StudentId = 27 },
                new ClassStudent { ClassId = 8, StudentId = 28 },
                new ClassStudent { ClassId = 8, StudentId = 29 },
                new ClassStudent { ClassId = 8, StudentId = 30 },
                new ClassStudent { ClassId = 8, StudentId = 31 },
                new ClassStudent { ClassId = 8, StudentId = 32 },
                new ClassStudent { ClassId = 8, StudentId = 33 },
                new ClassStudent { ClassId = 8, StudentId = 34 },
                new ClassStudent { ClassId = 8, StudentId = 35 },
                new ClassStudent { ClassId = 8, StudentId = 36 },
                new ClassStudent { ClassId = 8, StudentId = 37 },
                new ClassStudent { ClassId = 8, StudentId = 38 },

                // Class 9
                new ClassStudent { ClassId = 9, StudentId = 39 },
                new ClassStudent { ClassId = 9, StudentId = 40 },
                new ClassStudent { ClassId = 9, StudentId = 41 },
                new ClassStudent { ClassId = 9, StudentId = 42 },
                new ClassStudent { ClassId = 9, StudentId = 43 },
                new ClassStudent { ClassId = 9, StudentId = 44 },
                new ClassStudent { ClassId = 9, StudentId = 45 },
                new ClassStudent { ClassId = 9, StudentId = 46 },
                new ClassStudent { ClassId = 9, StudentId = 47 },
                new ClassStudent { ClassId = 9, StudentId = 48 },
                new ClassStudent { ClassId = 9, StudentId = 49 },
                new ClassStudent { ClassId = 9, StudentId = 50 },
                new ClassStudent { ClassId = 9, StudentId = 1 },
                new ClassStudent { ClassId = 9, StudentId = 2 },

                // Class 10
                new ClassStudent { ClassId = 10, StudentId = 3 },
                new ClassStudent { ClassId = 10, StudentId = 4 },
                new ClassStudent { ClassId = 10, StudentId = 5 },
                new ClassStudent { ClassId = 10, StudentId = 6 },
                new ClassStudent { ClassId = 10, StudentId = 7 },
                new ClassStudent { ClassId = 10, StudentId = 8 },
                new ClassStudent { ClassId = 10, StudentId = 9 },
                new ClassStudent { ClassId = 10, StudentId = 10 },
                new ClassStudent { ClassId = 10, StudentId = 11 },
                new ClassStudent { ClassId = 10, StudentId = 12 },
                new ClassStudent { ClassId = 10, StudentId = 13 },
                new ClassStudent { ClassId = 10, StudentId = 14 },
                new ClassStudent { ClassId = 10, StudentId = 15 },
                new ClassStudent { ClassId = 10, StudentId = 16 },

                // Class 11
                new ClassStudent { ClassId = 11, StudentId = 17 },
                new ClassStudent { ClassId = 11, StudentId = 18 },
                new ClassStudent { ClassId = 11, StudentId = 19 },
                new ClassStudent { ClassId = 11, StudentId = 20 },
                new ClassStudent { ClassId = 11, StudentId = 21 },
                new ClassStudent { ClassId = 11, StudentId = 22 },
                new ClassStudent { ClassId = 11, StudentId = 23 },
                new ClassStudent { ClassId = 11, StudentId = 24 },
                new ClassStudent { ClassId = 11, StudentId = 25 },
                new ClassStudent { ClassId = 11, StudentId = 26 },
                new ClassStudent { ClassId = 11, StudentId = 27 },
                new ClassStudent { ClassId = 11, StudentId = 28 },
                new ClassStudent { ClassId = 11, StudentId = 29 },
                new ClassStudent { ClassId = 11, StudentId = 30 },

                // Class 12
                new ClassStudent { ClassId = 12, StudentId = 31 },
                new ClassStudent { ClassId = 12, StudentId = 32 },
                new ClassStudent { ClassId = 12, StudentId = 33 },
                new ClassStudent { ClassId = 12, StudentId = 34 },
                new ClassStudent { ClassId = 12, StudentId = 35 },
                new ClassStudent { ClassId = 12, StudentId = 36 },
                new ClassStudent { ClassId = 12, StudentId = 37 },
                new ClassStudent { ClassId = 12, StudentId = 38 },
                new ClassStudent { ClassId = 12, StudentId = 39 },
                new ClassStudent { ClassId = 12, StudentId = 40 },
                new ClassStudent { ClassId = 12, StudentId = 41 },
                new ClassStudent { ClassId = 12, StudentId = 42 },
                new ClassStudent { ClassId = 12, StudentId = 43 },
                new ClassStudent { ClassId = 12, StudentId = 44 },

                // Class 13
                new ClassStudent { ClassId = 13, StudentId = 45 },
                new ClassStudent { ClassId = 13, StudentId = 46 },
                new ClassStudent { ClassId = 13, StudentId = 47 },
                new ClassStudent { ClassId = 13, StudentId = 48 },
                new ClassStudent { ClassId = 13, StudentId = 49 },
                new ClassStudent { ClassId = 13, StudentId = 50 },
                new ClassStudent { ClassId = 13, StudentId = 1 },
                new ClassStudent { ClassId = 13, StudentId = 2 },
                new ClassStudent { ClassId = 13, StudentId = 3 },
                new ClassStudent { ClassId = 13, StudentId = 4 },
                new ClassStudent { ClassId = 13, StudentId = 5 },
                new ClassStudent { ClassId = 13, StudentId = 6 },
                new ClassStudent { ClassId = 13, StudentId = 7 },
                new ClassStudent { ClassId = 13, StudentId = 8 },

                // Class 14
                new ClassStudent { ClassId = 14, StudentId = 9 },
                new ClassStudent { ClassId = 14, StudentId = 10 },
                new ClassStudent { ClassId = 14, StudentId = 11 },
                new ClassStudent { ClassId = 14, StudentId = 12 },
                new ClassStudent { ClassId = 14, StudentId = 13 },
                new ClassStudent { ClassId = 14, StudentId = 14 },
                new ClassStudent { ClassId = 14, StudentId = 15 },
                new ClassStudent { ClassId = 14, StudentId = 16 },
                new ClassStudent { ClassId = 14, StudentId = 17 },
                new ClassStudent { ClassId = 14, StudentId = 18 },
                new ClassStudent { ClassId = 14, StudentId = 19 },
                new ClassStudent { ClassId = 14, StudentId = 20 },
                new ClassStudent { ClassId = 14, StudentId = 21 },
                new ClassStudent { ClassId = 14, StudentId = 22 },

                // Class 15
                new ClassStudent { ClassId = 15, StudentId = 23 },
                new ClassStudent { ClassId = 15, StudentId = 24 },
                new ClassStudent { ClassId = 15, StudentId = 25 },
                new ClassStudent { ClassId = 15, StudentId = 26 },
                new ClassStudent { ClassId = 15, StudentId = 27 },
                new ClassStudent { ClassId = 15, StudentId = 28 },
                new ClassStudent { ClassId = 15, StudentId = 29 },
                new ClassStudent { ClassId = 15, StudentId = 30 },
                new ClassStudent { ClassId = 15, StudentId = 31 },
                new ClassStudent { ClassId = 15, StudentId = 32 },
                new ClassStudent { ClassId = 15, StudentId = 33 },
                new ClassStudent { ClassId = 15, StudentId = 34 },
                new ClassStudent { ClassId = 15, StudentId = 35 },
                new ClassStudent { ClassId = 15, StudentId = 36 },

                // Class 16
                new ClassStudent { ClassId = 16, StudentId = 37 },
                new ClassStudent { ClassId = 16, StudentId = 38 },
                new ClassStudent { ClassId = 16, StudentId = 39 },
                new ClassStudent { ClassId = 16, StudentId = 40 },
                new ClassStudent { ClassId = 16, StudentId = 41 },
                new ClassStudent { ClassId = 16, StudentId = 42 },
                new ClassStudent { ClassId = 16, StudentId = 43 },
                new ClassStudent { ClassId = 16, StudentId = 44 },
                new ClassStudent { ClassId = 16, StudentId = 45 },
                new ClassStudent { ClassId = 16, StudentId = 46 },
                new ClassStudent { ClassId = 16, StudentId = 47 },
                new ClassStudent { ClassId = 16, StudentId = 48 },
                new ClassStudent { ClassId = 16, StudentId = 49 },
                new ClassStudent { ClassId = 16, StudentId = 50 },

                // Class 17
                new ClassStudent { ClassId = 17, StudentId = 1 },
                new ClassStudent { ClassId = 17, StudentId = 2 },
                new ClassStudent { ClassId = 17, StudentId = 3 },
                new ClassStudent { ClassId = 17, StudentId = 4 },
                new ClassStudent { ClassId = 17, StudentId = 5 },
                new ClassStudent { ClassId = 17, StudentId = 6 },
                new ClassStudent { ClassId = 17, StudentId = 7 },
                new ClassStudent { ClassId = 17, StudentId = 8 },
                new ClassStudent { ClassId = 17, StudentId = 9 },
                new ClassStudent { ClassId = 17, StudentId = 10 },
                new ClassStudent { ClassId = 17, StudentId = 11 },
                new ClassStudent { ClassId = 17, StudentId = 12 },
                new ClassStudent { ClassId = 17, StudentId = 13 },
                new ClassStudent { ClassId = 17, StudentId = 14 },

                // Class 18
                new ClassStudent { ClassId = 18, StudentId = 15 },
                new ClassStudent { ClassId = 18, StudentId = 16 },
                new ClassStudent { ClassId = 18, StudentId = 17 },
                new ClassStudent { ClassId = 18, StudentId = 18 },
                new ClassStudent { ClassId = 18, StudentId = 19 },
                new ClassStudent { ClassId = 18, StudentId = 20 },
                new ClassStudent { ClassId = 18, StudentId = 21 },
                new ClassStudent { ClassId = 18, StudentId = 22 },
                new ClassStudent { ClassId = 18, StudentId = 23 },
                new ClassStudent { ClassId = 18, StudentId = 24 },
                new ClassStudent { ClassId = 18, StudentId = 25 },
                new ClassStudent { ClassId = 18, StudentId = 26 },
                new ClassStudent { ClassId = 18, StudentId = 27 },
                new ClassStudent { ClassId = 18, StudentId = 28 }
                );
            #endregion
        }
    }
}
