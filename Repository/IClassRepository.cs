using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EngLabAPI.DTOs.Class;
using EngLabAPI.Model.Entities;

namespace EngLabAPI.Repository
{
    public interface IClassRepository
    {
        public Task<IEnumerable<GetClassDTO>> GetByPageAndFilterAsync(string? name, int page, int pageSize);
        public Task<int> CountAllAsync();

        public Task<GetClassDTO> GetByIdAsync(int id);

        public Task<bool> CreateAsync(CreateClassDTO classDTO);

        public Task<bool> UpdateAsync(int id, UpdateClassDTO classDTO);

        public Task<bool> DeleteAsync(int id);
    }
}