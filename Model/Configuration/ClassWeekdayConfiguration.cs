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
    public class ClassWeekdayConfiguration : IEntityTypeConfiguration<ClassWeekday>
    {
        public void Configure(EntityTypeBuilder<ClassWeekday> builder)
        {
            builder.HasKey(x => new { x.ClassId, x.WeekdayId });
            builder.HasOne(x => x.Weekday).WithMany(x => x.ClassWeekday).HasForeignKey(x => x.WeekdayId);
            builder.HasOne(x => x.Class).WithMany(x => x.ClassWeekday).HasForeignKey(x => x.ClassId);

            builder.Property(x => x.StartTime).IsRequired();
            builder.Property(x => x.EndTime).IsRequired();

            #region Seed Data
            builder.HasData(
                // Class 1
                new ClassWeekday { ClassId = 1, WeekdayId = 1, StartTime = new DateTime(2024, 9, 23, 8, 0, 0), EndTime = new DateTime(2024, 9, 23, 10, 0, 0) }, // Monday, 08:00-10:00
                new ClassWeekday { ClassId = 1, WeekdayId = 3, StartTime = new DateTime(2024, 9, 25, 10, 0, 0), EndTime = new DateTime(2024, 9, 25, 12, 0, 0) }, // Wednesday, 10:00-12:00
                new ClassWeekday { ClassId = 1, WeekdayId = 5, StartTime = new DateTime(2024, 9, 27, 13, 0, 0), EndTime = new DateTime(2024, 9, 27, 15, 0, 0) }, // Friday, 13:00-15:00

                // Class 2
                new ClassWeekday { ClassId = 2, WeekdayId = 2, StartTime = new DateTime(2024, 9, 24, 9, 0, 0), EndTime = new DateTime(2024, 9, 24, 11, 0, 0) }, // Tuesday, 09:00-11:00
                new ClassWeekday { ClassId = 2, WeekdayId = 4, StartTime = new DateTime(2024, 9, 26, 11, 0, 0), EndTime = new DateTime(2024, 9, 26, 13, 0, 0) }, // Thursday, 11:00-13:00
                new ClassWeekday { ClassId = 2, WeekdayId = 6, StartTime = new DateTime(2024, 9, 28, 14, 0, 0), EndTime = new DateTime(2024, 9, 28, 16, 0, 0) }, // Saturday, 14:00-16:00

                // Class 3
                new ClassWeekday { ClassId = 3, WeekdayId = 1, StartTime = new DateTime(2024, 9, 23, 15, 0, 0), EndTime = new DateTime(2024, 9, 23, 17, 0, 0) }, // Monday, 15:00-17:00
                new ClassWeekday { ClassId = 3, WeekdayId = 4, StartTime = new DateTime(2024, 9, 26, 8, 0, 0), EndTime = new DateTime(2024, 9, 26, 10, 0, 0) }, // Thursday, 08:00-10:00
                new ClassWeekday { ClassId = 3, WeekdayId = 6, StartTime = new DateTime(2024, 9, 28, 16, 0, 0), EndTime = new DateTime(2024, 9, 28, 18, 0, 0) }, // Saturday, 16:00-18:00

                // Class 4
                new ClassWeekday { ClassId = 4, WeekdayId = 2, StartTime = new DateTime(2024, 9, 24, 13, 0, 0), EndTime = new DateTime(2024, 9, 24, 15, 0, 0) }, // Tuesday, 13:00-15:00
                new ClassWeekday { ClassId = 4, WeekdayId = 3, StartTime = new DateTime(2024, 9, 25, 9, 0, 0), EndTime = new DateTime(2024, 9, 25, 11, 0, 0) }, // Wednesday, 09:00-11:00
                new ClassWeekday { ClassId = 4, WeekdayId = 5, StartTime = new DateTime(2024, 9, 27, 15, 0, 0), EndTime = new DateTime(2024, 9, 27, 17, 0, 0) }, // Friday, 15:00-17:00

                // Class 5
                new ClassWeekday { ClassId = 5, WeekdayId = 1, StartTime = new DateTime(2024, 9, 23, 10, 0, 0), EndTime = new DateTime(2024, 9, 23, 12, 0, 0) }, // Monday, 10:00-12:00
                new ClassWeekday { ClassId = 5, WeekdayId = 2, StartTime = new DateTime(2024, 9, 24, 14, 0, 0), EndTime = new DateTime(2024, 9, 24, 16, 0, 0) }, // Tuesday, 14:00-16:00
                new ClassWeekday { ClassId = 5, WeekdayId = 4, StartTime = new DateTime(2024, 9, 26, 11, 0, 0), EndTime = new DateTime(2024, 9, 26, 13, 0, 0) }, // Thursday, 11:00-13:00

                // Class 6
                new ClassWeekday { ClassId = 6, WeekdayId = 3, StartTime = new DateTime(2024, 9, 25, 8, 0, 0), EndTime = new DateTime(2024, 9, 25, 10, 0, 0) }, // Wednesday, 08:00-10:00
                new ClassWeekday { ClassId = 6, WeekdayId = 4, StartTime = new DateTime(2024, 9, 26, 13, 0, 0), EndTime = new DateTime(2024, 9, 26, 15, 0, 0) }, // Thursday, 13:00-15:00
                new ClassWeekday { ClassId = 6, WeekdayId = 6, StartTime = new DateTime(2024, 9, 28, 10, 0, 0), EndTime = new DateTime(2024, 9, 28, 12, 0, 0) }, // Saturday, 10:00-12:00

                // Class 7
                new ClassWeekday { ClassId = 7, WeekdayId = 2, StartTime = new DateTime(2024, 9, 24, 8, 0, 0), EndTime = new DateTime(2024, 9, 24, 10, 0, 0) }, // Tuesday, 08:00-10:00
                new ClassWeekday { ClassId = 7, WeekdayId = 3, StartTime = new DateTime(2024, 9, 25, 11, 0, 0), EndTime = new DateTime(2024, 9, 25, 13, 0, 0) }, // Wednesday, 11:00-13:00
                new ClassWeekday { ClassId = 7, WeekdayId = 5, StartTime = new DateTime(2024, 9, 27, 14, 0, 0), EndTime = new DateTime(2024, 9, 27, 16, 0, 0) }, // Friday, 14:00-16:00

                // Class 8
                new ClassWeekday { ClassId = 8, WeekdayId = 1, StartTime = new DateTime(2024, 9, 23, 8, 0, 0), EndTime = new DateTime(2024, 9, 23, 10, 0, 0) }, // Monday, 08:00-10:00
                new ClassWeekday { ClassId = 8, WeekdayId = 4, StartTime = new DateTime(2024, 9, 26, 10, 0, 0), EndTime = new DateTime(2024, 9, 26, 12, 0, 0) }, // Thursday, 10:00-12:00
                new ClassWeekday { ClassId = 8, WeekdayId = 6, StartTime = new DateTime(2024, 9, 28, 13, 0, 0), EndTime = new DateTime(2024, 9, 28, 15, 0, 0) }, // Saturday, 13:00-15:00

                // Class 9
                new ClassWeekday { ClassId = 9, WeekdayId = 2, StartTime = new DateTime(2024, 9, 24, 10, 0, 0), EndTime = new DateTime(2024, 9, 24, 12, 0, 0) }, // Tuesday, 10:00-12:00
                new ClassWeekday { ClassId = 9, WeekdayId = 3, StartTime = new DateTime(2024, 9, 25, 14, 0, 0), EndTime = new DateTime(2024, 9, 25, 16, 0, 0) }, // Wednesday, 14:00-16:00
                new ClassWeekday { ClassId = 9, WeekdayId = 6, StartTime = new DateTime(2024, 9, 28, 9, 0, 0), EndTime = new DateTime(2024, 9, 28, 11, 0, 0) }, // Saturday, 09:00-11:00

                // Class 10
                new ClassWeekday { ClassId = 10, WeekdayId = 1, StartTime = new DateTime(2024, 9, 23, 11, 0, 0), EndTime = new DateTime(2024, 9, 23, 13, 0, 0) }, // Monday, 11:00-13:00
                new ClassWeekday { ClassId = 10, WeekdayId = 3, StartTime = new DateTime(2024, 9, 25, 16, 0, 0), EndTime = new DateTime(2024, 9, 25, 18, 0, 0) }, // Wednesday, 16:00-18:00
                new ClassWeekday { ClassId = 10, WeekdayId = 5, StartTime = new DateTime(2024, 9, 27, 8, 0, 0), EndTime = new DateTime(2024, 9, 27, 10, 0, 0) }, // Friday, 08:00-10:00

                // Class 11
                new ClassWeekday { ClassId = 11, WeekdayId = 2, StartTime = new DateTime(2024, 9, 24, 15, 0, 0), EndTime = new DateTime(2024, 9, 24, 17, 0, 0) }, // Tuesday, 15:00-17:00
                new ClassWeekday { ClassId = 11, WeekdayId = 4, StartTime = new DateTime(2024, 9, 26, 8, 0, 0), EndTime = new DateTime(2024, 9, 26, 10, 0, 0) }, // Thursday, 08:00-10:00
                new ClassWeekday { ClassId = 11, WeekdayId = 6, StartTime = new DateTime(2024, 9, 28, 14, 0, 0), EndTime = new DateTime(2024, 9, 28, 16, 0, 0) }, // Saturday, 14:00-16:00

                // Class 12
                new ClassWeekday { ClassId = 12, WeekdayId = 1, StartTime = new DateTime(2024, 9, 23, 13, 0, 0), EndTime = new DateTime(2024, 9, 23, 15, 0, 0) }, // Monday, 13:00-15:00
                new ClassWeekday { ClassId = 12, WeekdayId = 3, StartTime = new DateTime(2024, 9, 25, 9, 0, 0), EndTime = new DateTime(2024, 9, 25, 11, 0, 0) }, // Wednesday, 09:00-11:00
                new ClassWeekday { ClassId = 12, WeekdayId = 5, StartTime = new DateTime(2024, 9, 27, 11, 0, 0), EndTime = new DateTime(2024, 9, 27, 13, 0, 0) }, // Friday, 11:00-13:00

                // Class 13
                new ClassWeekday { ClassId = 13, WeekdayId = 2, StartTime = new DateTime(2024, 9, 24, 9, 0, 0), EndTime = new DateTime(2024, 9, 24, 11, 0, 0) }, // Tuesday, 09:00-11:00
                new ClassWeekday { ClassId = 13, WeekdayId = 4, StartTime = new DateTime(2024, 9, 26, 13, 0, 0), EndTime = new DateTime(2024, 9, 26, 15, 0, 0) }, // Thursday, 13:00-15:00
                new ClassWeekday { ClassId = 13, WeekdayId = 6, StartTime = new DateTime(2024, 9, 28, 11, 0, 0), EndTime = new DateTime(2024, 9, 28, 13, 0, 0) }, // Saturday, 11:00-13:00


                // Class 14
                new ClassWeekday { ClassId = 14, WeekdayId = 1, StartTime = new DateTime(2024, 9, 23, 15, 0, 0), EndTime = new DateTime(2024, 9, 23, 17, 0, 0) }, // Monday, 15:00-17:00
                new ClassWeekday { ClassId = 14, WeekdayId = 3, StartTime = new DateTime(2024, 9, 25, 10, 0, 0), EndTime = new DateTime(2024, 9, 25, 12, 0, 0) }, // Wednesday, 10:00-12:00
                new ClassWeekday { ClassId = 14, WeekdayId = 5, StartTime = new DateTime(2024, 9, 27, 13, 0, 0), EndTime = new DateTime(2024, 9, 27, 15, 0, 0) }, // Friday, 13:00-15:00

                // Class 15
                new ClassWeekday { ClassId = 15, WeekdayId = 2, StartTime = new DateTime(2024, 9, 24, 10, 0, 0), EndTime = new DateTime(2024, 9, 24, 12, 0, 0) }, // Tuesday, 10:00-12:00
                new ClassWeekday { ClassId = 15, WeekdayId = 4, StartTime = new DateTime(2024, 9, 26, 14, 0, 0), EndTime = new DateTime(2024, 9, 26, 16, 0, 0) }, // Thursday, 14:00-16:00
                new ClassWeekday { ClassId = 15, WeekdayId = 6, StartTime = new DateTime(2024, 9, 28, 15, 0, 0), EndTime = new DateTime(2024, 9, 28, 17, 0, 0) }, // Saturday, 15:00-17:00

                // Class 16
                new ClassWeekday { ClassId = 16, WeekdayId = 1, StartTime = new DateTime(2024, 9, 23, 9, 0, 0), EndTime = new DateTime(2024, 9, 23, 11, 0, 0) }, // Monday, 09:00-11:00
                new ClassWeekday { ClassId = 16, WeekdayId = 3, StartTime = new DateTime(2024, 9, 25, 13, 0, 0), EndTime = new DateTime(2024, 9, 25, 15, 0, 0) }, // Wednesday, 13:00-15:00
                new ClassWeekday { ClassId = 16, WeekdayId = 5, StartTime = new DateTime(2024, 9, 27, 8, 0, 0), EndTime = new DateTime(2024, 9, 27, 10, 0, 0) }, // Friday, 08:00-10:00

                // Class 17
                new ClassWeekday { ClassId = 17, WeekdayId = 2, StartTime = new DateTime(2024, 9, 24, 11, 0, 0), EndTime = new DateTime(2024, 9, 24, 13, 0, 0) }, // Tuesday, 11:00-13:00
                new ClassWeekday { ClassId = 17, WeekdayId = 4, StartTime = new DateTime(2024, 9, 26, 9, 0, 0), EndTime = new DateTime(2024, 9, 26, 11, 0, 0) }, // Thursday, 09:00-11:00
                new ClassWeekday { ClassId = 17, WeekdayId = 6, StartTime = new DateTime(2024, 9, 28, 14, 0, 0), EndTime = new DateTime(2024, 9, 28, 16, 0, 0) }, // Saturday, 14:00-16:00

                // Class 18
                new ClassWeekday { ClassId = 18, WeekdayId = 1, StartTime = new DateTime(2024, 9, 23, 10, 0, 0), EndTime = new DateTime(2024, 9, 23, 12, 0, 0) }, // Monday, 10:00-12:00
                new ClassWeekday { ClassId = 18, WeekdayId = 3, StartTime = new DateTime(2024, 9, 25, 15, 0, 0), EndTime = new DateTime(2024, 9, 25, 17, 0, 0) }, // Wednesday, 15:00-17:00
                new ClassWeekday { ClassId = 18, WeekdayId = 5, StartTime = new DateTime(2024, 9, 27, 11, 0, 0), EndTime = new DateTime(2024, 9, 27, 13, 0, 0) } // Friday, 11:00-13:00
                );
            #endregion
        }
    }
}
