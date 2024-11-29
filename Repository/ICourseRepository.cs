using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EngLabAPI.DTOs.Course;
using EngLabAPI.Model.Entities;

namespace EngLabAPI.Repository
{
    public interface ICourseRepository
    {
        public Task<IEnumerable<GetCourseDTO>> GetByPageAndFilterAsync(string? name, int page, int pageSize);
        public Task<int> CountAllAsync();

        public Task<GetCourseDTO> GetByIdAsync(int id);

        public Task<bool> CreateAsync(CreateCourseDTO courseDTO);

        public Task<bool> UpdateAsync(int id, UpdateCourseDTO courseDTO);

        public Task<bool> DeleteAsync(int id);

        public Task<IEnumerable<Language>> GetAllLanguagesAsync();

        public Task<IEnumerable<Level>> GetAllLevelsAsync();

        public Task<IEnumerable<Level>> GetLevelByLanguageIdAsync(int languageId);


    }
}