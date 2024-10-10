using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngLabAPI.Model.Entities
{
    public class Course
    {
        public int Id { get; set; }

        public string? CourseCode { get; set; }

        public string? CourseName { get; set; }

        public string? Description { get; set; }

        public string? Duration { get; set; }

        public double Fee { get; set; }

        public double Discount { get; set; }

        public double TotalFee { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int LevelId { get; set; }
        public Level? Level { get; set; }

        public ICollection<Class>? Class { get; set; }
        public ICollection<Payment>? Payment { get; set; }
    }
}
