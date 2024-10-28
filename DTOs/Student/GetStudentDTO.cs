using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EngLabAPI.DTOs.Student
{
    public class GetStudentDTO
    {
        public Guid Id { get; set;}

        public string? StudentCode { get; set; }

        public string? FullName { get; set; }

        public string? Gender { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public string? Status { get; set; }
    }
}