using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngLabAPI.Model.Entities
{
    public class Student
    {
        public int Id { get; set; }

        public string? StudentCode { get; set; }

        public string? FullName { get; set; }

        public string? Gender { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public string? Status { get; set; }

        public ICollection<ClassStudent>? ClassStudent { get; set; }
        public ICollection<Payment>? Payment { get; set; }
    }
}
