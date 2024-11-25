using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EngLabAPI.DTOs.Course;
using EngLabAPI.Model.Context;
using EngLabAPI.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace EngLabAPI.Repository
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(EngLabContext context) : base(context)
        {

        }

        
        public new async Task<List<GetCourseDTO>> GetByPageAndFilterAsync(string? name, int page, int pageSize)
        {
            // Base query
            var query = _context.Course
                .Join(
                    _context.Level,
                    c => c.LevelId,
                    l => l.Id,
                    (c, l) => new { Course = c, Level = l }
                );

            // Filter by name if provided
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(x => x.Course.CourseName!.Contains(name));
            }

            // Apply pagination
            var paginatedQuery = query
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            // Project to DTO
            var result = paginatedQuery
                .Select(x => new GetCourseDTO
                {
                    Id = x.Course.Id,
                    CourseCode = x.Course.CourseCode,
                    CourseName = x.Course.CourseName,
                    Description = x.Course.Description,
                    Duration = x.Course.Duration,
                    Fee = x.Course.Fee,
                    Discount = x.Course.Discount,
                    TotalFee = x.Course.TotalFee,
                    IsActive = x.Course.IsActive,
                    CreatedDate = x.Course.CreatedDate,
                    UpdatedDate = x.Course.UpdatedDate,
                    LevelId = x.Level.Id,
                    LevelName = x.Level.LevelName
                });

            return await result.ToListAsync();
        }
    }
}
