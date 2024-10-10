using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EngLabAPI.Repository;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace EngLabAPI.Queries.Student
{
    public class GetStudentByPageQueryHandler : IRequestHandler<GetStudentByPageQuery, IEnumerable<EngLabAPI.DTOs.StudentDTO>>
    {
        private readonly IStudentRepostory _studentRepository;
        private readonly IMapper _mapper;

        public GetStudentByPageQueryHandler(IStudentRepostory studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DTOs.StudentDTO>> Handle(GetStudentByPageQuery request, CancellationToken cancellationToken)
        {
            var students = await _studentRepository.GetByPageAsync(request.page, request.pagesize);
            if (!students.Any())
            {
                throw new KeyNotFoundException("No students found for the given page.");
            }
            return _mapper.Map<IEnumerable<DTOs.StudentDTO>>(students);
        }
    }
}

