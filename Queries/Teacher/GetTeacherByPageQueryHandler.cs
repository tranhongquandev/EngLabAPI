using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EngLabAPI.Repository;
using MediatR;
using Microsoft.Identity.Client;

namespace EngLabAPI.Queries.Teacher
{
    public class GetTeacherByPageQueryHandler : IRequestHandler<GetTeacherByPageQuery, IEnumerable<EngLabAPI.DTOs.TeacherDTO>>
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IMapper _mapper;

        public GetTeacherByPageQueryHandler(ITeacherRepository teacherRepository, IMapper mapper)
        {
            _teacherRepository = teacherRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EngLabAPI.DTOs.TeacherDTO>> Handle(GetTeacherByPageQuery request, CancellationToken cancellationToken)
        {
            var teacher = await _teacherRepository.GetByPageAsync(request.page, request.pagesize);

            if (!teacher.Any())
            {
                throw new KeyNotFoundException("No teacher found");

            }
            return _mapper.Map<IEnumerable<EngLabAPI.DTOs.TeacherDTO>>(teacher);

        }
    }

}