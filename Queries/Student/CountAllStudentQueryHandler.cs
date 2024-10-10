using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EngLabAPI.Repository;
using MediatR;

namespace EngLabAPI.Queries.Student
{
    public class CountAllStudentQueryHandler : IRequestHandler<CountAllStudentQuery, int>
    {
        private readonly IStudentRepostory _studentRepostory;

        public CountAllStudentQueryHandler(IStudentRepostory studentRepostory)
        {
            _studentRepostory = studentRepostory;
        }

        public async Task<int> Handle(CountAllStudentQuery request, CancellationToken cancellationToken)
        {
            return await _studentRepostory.CountAllAsync();
        }
    }
}