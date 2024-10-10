using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace EngLabAPI.Queries.Teacher
{
    public class GetTeacherByPageQuery : IRequest<IEnumerable<EngLabAPI.DTOs.TeacherDTO>>
    {
        public int page { get; set; }
        public int pagesize { get; set; }
    }
}