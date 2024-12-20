using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EngLabAPI.DTOs.Course
{
    public class UpdateCourseDTO
    {
        public string? CourseCode { get; set; }

        public string? CourseName { get; set; }

        public string? Description { get; set; }

        public string? Duration { get; set; }

        public double Fee { get; set; }

        public double Discount { get; set; }

        public bool IsActive { get; set; }
        public int LevelId { get; set; }
    }
}