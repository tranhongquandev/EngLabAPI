using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EngLabAPI.Repository;
using MediatR;

namespace EngLabAPI.Queries.Teacher
{
    public class CountAllTeacherQueryHandler : IRequestHandler<CountAllTeacherQuery, int>
    {
        private readonly ITeacherRepository _teacherRepository;

        public CountAllTeacherQueryHandler(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task<int> Handle(CountAllTeacherQuery request, CancellationToken cancellationToken)
        {
            return await _teacherRepository.CountAllAsync();
        }
    }
}