using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EngLabAPI.DTOs.Class;
using EngLabAPI.DTOs.Student;
using EngLabAPI.Model.Entities;

namespace EngLabAPI.Repository
{
    public interface IClassRepository
    {
        public Task<IEnumerable<GetClassDTO>> GetByPageAndFilterAsync(string? name, int page, int pageSize);
        public Task<int> CountAllAsync();

        public Task<bool> AddStudentAsync(int classId, List<int> studentId);

        public Task<bool> RemoveStudentAsync(int classId, List<int> studentId);

        public Task<IEnumerable<GetStudentDTO>> GetStudenInClassAsync(int classId);

        public Task<IEnumerable<GetStudentDTO>> GetStudentNotInClassAsync(int classId);

        public Task<GetClassDTO> GetByIdAsync(int id);

        public Task<bool> CreateAsync(CreateClassDTO classDTO);

        public Task<bool> UpdateAsync(int id, UpdateClassDTO classDTO);

        public Task<bool> DeleteAsync(int id);
    }
}