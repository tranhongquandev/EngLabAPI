using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using MediatR;

namespace EngLabAPI.Queries.Student
{
    public class GetStudentByPageQuery : IRequest<IEnumerable<EngLabAPI.DTOs.StudentDTO>>
    {
        [Required]
        public int page { get; set; }

        [Required]

        public int pagesize { get; set; }
    }
}