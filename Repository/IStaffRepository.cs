using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EngLabAPI.DTOs.Staff;
using EngLabAPI.Model.Entities;

namespace EngLabAPI.Repository
{
    public interface IStaffRepository
    {
        public Task<IEnumerable<GetStaffDTO>> GetByPageAndFilterAsync(string? name, int? page, int? pageSize, int? userId);
        public Task<GetStaffDTO> GetByIdAsync(int id);

        public Task<bool> CreateAsync(CreateStaffDTO staffDTO);

        public Task<bool> UpdateAsync(int id, UpdateStaffDTO staffDTO);

        public Task<bool> DeleteAsync(int id);

        public Task<IEnumerable<StaffRole>> GetAllRolesAsync(int? userId);
    }
}