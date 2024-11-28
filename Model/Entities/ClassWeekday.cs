using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngLabAPI.Model.Entities
{
    public class ClassWeekday
    {
        public int ClassId { get; set; }


        public int WeekdayId { get; set; }


        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
