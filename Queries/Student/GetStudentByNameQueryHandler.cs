using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EngLabAPI.DTOs;
using EngLabAPI.Repository;
using MediatR;

namespace EngLabAPI.Queries.Student
{
    public class GetStudentByNameQueryHandler : IRequestHandler<GetStudentByNameQuery, IEnumerable<StudentDTO>>
    {
        private readonly IStudentRepostory _studentRepostory;
        private readonly IMapper _mapper;

        public GetStudentByNameQueryHandler(IStudentRepostory studentRepostory, IMapper mapper)
        {
            _studentRepostory = studentRepostory;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StudentDTO>> Handle(GetStudentByNameQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentRepostory.FindAsync(x => x.FullName == request.name);
            if(!student.Any()) {
                throw new KeyNotFoundException("Student not found");
            }
            return _mapper.Map<IEnumerable<StudentDTO>>(student);

        }
    }
}