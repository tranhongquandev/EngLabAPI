using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EngLabAPI.DTOs;
using MediatR;

namespace EngLabAPI.Queries.Student
{
    public class GetStudentByNameQuery : IRequest<IEnumerable<StudentDTO>>
    {
        [Required]
        public string? name { get; set; }
    }
}