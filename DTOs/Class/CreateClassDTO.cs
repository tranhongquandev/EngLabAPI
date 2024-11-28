using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EngLabAPI.DTOs.Class
{
    public class CreateClassDTO
    {
        public string? ClassCode { get; set; }

        public string? ClassName { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int CourseId { get; set; }

        public int TeacherId { get; set; }
    }
}