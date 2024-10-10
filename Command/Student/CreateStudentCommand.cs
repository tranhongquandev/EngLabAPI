using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace EngLabAPI.Command.Student
{
    public class CreateStudentCommand : IRequest<int>
    {

        public string? FullName { get; set; }

        public string? Gender { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public string? Status { get; set; }
    }
}