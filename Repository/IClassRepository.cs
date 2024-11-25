using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EngLabAPI.DTOs.Class;
using EngLabAPI.Model.Entities;

namespace EngLabAPI.Repository
{
    public interface IClassRepository : IGenericRepository<Class>
    {
        new Task<List<GetClassDTO>> GetByPageAndFilterAsync(string? name, int page, int pageSize);
    }
}