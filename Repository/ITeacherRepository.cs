using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EngLabAPI.DTOs.Class;
using EngLabAPI.DTOs.Teacher;
using EngLabAPI.Model.Entities;

namespace EngLabAPI.Repository
{
    public interface ITeacherRepository
    {
        public Task<IEnumerable<Teacher>> GetByPageAndFilterAsync(string? name, int page, int pageSize);
        public Task<int> CountAllAsync();

        public Task<Teacher> GetByIdAsync(int id);

        public Task<bool> CreateAsync(CreateTeacherDTO teacher);

        public Task<bool> UpdateAsync(int id, UpdateTeacherDTO teacher);

        public Task<bool> DeleteAsync(int id);
    }
}