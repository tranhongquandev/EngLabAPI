using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EngLabAPI.DTOs.Course;
using EngLabAPI.Model.Entities;

namespace EngLabAPI.Repository
{
    public interface ICourseRepository : IGenericRepository<Course>
    {
        public new Task<List<GetCourseDTO>> GetByPageAndFilterAsync(string? name, int page, int pageSize);
    }
}