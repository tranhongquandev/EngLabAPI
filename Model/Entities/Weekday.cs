using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngLabAPI.Model.Entities
{
    public class Weekday
    {
        public int Id { get; set; }

        public string? DayName { get; set; }

        public ICollection<ClassWeekday>? ClassWeekday { get; set; }
    }
}
