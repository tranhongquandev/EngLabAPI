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
    public class WeekdayConfiguration : IEntityTypeConfiguration<Weekday>
    {
        public void Configure(EntityTypeBuilder<Weekday> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.DayName).HasMaxLength(50);

            builder.HasData(
                    new Weekday { Id = 1, DayName = "Monday" },
                    new Weekday { Id = 2, DayName = "Tuesday" },
                    new Weekday { Id = 3, DayName = "Wednesday" },
                    new Weekday { Id = 4, DayName = "Thursday" },
                    new Weekday { Id = 5, DayName = "Friday" },
                    new Weekday { Id = 6, DayName = "Saturday" },
                    new Weekday { Id = 7, DayName = "Sunday" }
                );
        }
    }
}
