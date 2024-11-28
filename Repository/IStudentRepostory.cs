using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EngLabAPI.DTOs.Student;
using EngLabAPI.Model.Entities;

namespace EngLabAPI.Repository
{
    public interface IStudentRepostory
    {

        public Task<IEnumerable<GetStudentDTO>> GetByPageAndFilterAsync(string? name, int page, int pageSize);
        public Task<int> CountAllAsync();

        public Task<Student> GetByIdAsync(int id);

        public Task<bool> CreateAsync(CreateStudentDTO studentDTO);

        public Task<bool> UpdateAsync(int id, UpdateStudentDTO studentDTO);

        public Task<bool> DeleteAsync(int id);

    }
}