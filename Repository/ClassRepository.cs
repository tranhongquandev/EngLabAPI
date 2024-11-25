using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EngLabAPI.DTOs.Class;
using EngLabAPI.Model.Context;
using EngLabAPI.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace EngLabAPI.Repository
{
    public class ClassRepository : GenericRepository<Class>, IClassRepository
    {
        public ClassRepository(EngLabContext context) : base(context)
        {
        }

        public new async Task<List<GetClassDTO>> GetByPageAndFilterAsync(string? name, int page, int pageSize)
        {
            // Base query with joins
            var query = _context.Class
                .Join(
                    _context.Teacher,
                    cls => cls.TeacherId,
                    teacher => teacher.Id,
                    (cls, teacher) => new { Class = cls, Teacher = teacher }
                )
                .Join(
                    _context.Course,
                    clsTeacher => clsTeacher.Class.CourseId,
                    course => course.Id,
                    (clsTeacher, course) => new { clsTeacher.Class, clsTeacher.Teacher, Course = course }
                );

            // Apply filtering by name if provided
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(x =>
                    x.Class.ClassName!.Contains(name) ||
                    x.Course.CourseName!.Contains(name) ||
                    x.Teacher.FullName!.Contains(name));
            }

            // Apply pagination
            var paginatedQuery = query
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            // Project to DTO
            var result = paginatedQuery
                .Select(x => new GetClassDTO
                {
                    Id = x.Class.Id,
                    ClassCode = x.Class.ClassCode,
                    ClassName = x.Class.ClassName,
                    CourseName = x.Course.CourseName,
                    TeacherName = x.Teacher.FullName,
                    StartDate = x.Class.StartDate,
                    EndDate = x.Class.EndDate,
                    CourseId = x.Course.Id,
                    TeacherId = x.Teacher.Id
                });

            return await result.ToListAsync();
        }

    }
}


