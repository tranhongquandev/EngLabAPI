using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngLabAPI.Model.Entities
{
    public class Class
    {
        public int Id { get; set; }

        public string? ClassCode { get; set; }

        public string? ClassName { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int CourseId { get; set; }
        public Course? Course { get; set; }

        public int TeacherId { get; set; }
        public Teacher? Teacher { get; set; }

        public ICollection<ClassStudent>? ClassStudent { get; set; }
        public ICollection<ClassWeekday>? ClassWeekday { get; set; }

    }
}
