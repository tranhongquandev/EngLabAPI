using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using EngLabAPI.DTOs.Class;
using EngLabAPI.DTOs.Student;
using EngLabAPI.Model.Entities;


namespace EngLabAPI.Repository
{
    public class ClassRepository : IClassRepository
    {
        private readonly IDbConnection _connection;

        public ClassRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<bool> AddStudentAsync(int classId, List<int> studentId)
        {
            var query = @"INSERT INTO ClassStudents (ClassId, StudentId)
                        VALUES (@ClassId, @StudentId)";

            var parameters = studentId.Select(studentId => new
            {
                ClassId = classId,
                StudentId = studentId
            }).ToList();

            return await _connection.ExecuteAsync(query, parameters) > 0;

        }

        public async Task<bool> RemoveStudentAsync(int classId, List<int> studentId)
        {
            var query = @"DELETE FROM ClassStudents WHERE ClassId = @ClassId AND StudentId = @StudentId";

            var parameters = studentId.Select(studentId => new
            {
                ClassId = classId,
                StudentId = studentId
            }).ToList();

            return await _connection.ExecuteAsync(query, parameters) > 0;
        }

        public async Task<IEnumerable<GetStudentDTO>> GetStudenInClassAsync(int classId)
        {
            var query = @"
                            SELECT * 
                            FROM Student s
                            INNER JOIN ClassStudents cs ON s.Id = cs.StudentId
                            WHERE cs.ClassId = @ClassId";
            return await _connection.QueryAsync<GetStudentDTO>(query, new { ClassId = classId });


        }
        public async Task<int> CountAllAsync()
        {
            var query = "SELECT COUNT(Id) FROM Class";
            return await _connection.QueryFirstOrDefaultAsync<int>(query);
        }

        public async Task<bool> CreateAsync(CreateClassDTO classDTO)
        {
            var query = @"INSERT INTO Class (ClassCode, ClassName, StartDate, EndDate, CourseId, TeacherId)
                        VALUES (@ClassCode, @ClassName, @StartDate, @EndDate, @CourseId, @TeacherId)";
            return await _connection.ExecuteAsync(query, classDTO) > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var query = @"DELETE FROM Class WHERE Id = @Id";
            return await _connection.ExecuteAsync(query, new { Id = id }) > 0;
        }

        public async Task<GetClassDTO> GetByIdAsync(int id)
        {
            var query = @"SELECT * 
            FROM Class c
            INNER JOIN Course co ON c.CourseId = co.Id
            INNER JOIN Teacher t ON c.TeacherId = t.Id
            WHERE Id = @Id";
            return await _connection.QueryFirstOrDefaultAsync<GetClassDTO>(query, new { Id = id }) ?? throw new KeyNotFoundException("Không tìm thấy lớp học");
        }

        public async Task<IEnumerable<GetClassDTO>> GetByPageAndFilterAsync(string? name, int page, int pageSize)
        {
            var query = @"
                            SELECT * 
                            FROM Class c
                            INNER JOIN Course co ON c.CourseId = co.Id
                            INNER JOIN Teacher t ON c.TeacherId = t.Id
                            c.ClassName IS NULL OR c.ClassName LIKE CONCAT('%', @name, '%')
                            ORDER BY c.Id
                            OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY
                            ";

            return await _connection.QueryAsync<GetClassDTO>(query, new { name, Offset = (page - 1) * pageSize, PageSize = pageSize });
        }

        public async Task<bool> UpdateAsync(int id, UpdateClassDTO classDTO)
        {
            var query = @"UPDATE Class
                        SET 
                            ClassCode = COALESCE(@ClassCode, ClassCode),
                            ClassName = COALESCE(@ClassName, ClassName),
                            StartDate = COALESCE(@StartDate, StartDate),
                            EndDate = COALESCE(@EndDate, EndDate),
                            CourseId = COALESCE(@CourseId, CourseId),
                            TeacherId = COALESCE(@TeacherId, TeacherId)
                        WHERE Id = @Id";

            var parameters = new DynamicParameters(new
            {
                Id = id,
                classDTO.ClassCode,
                classDTO.ClassName,
                classDTO.StartDate,
                classDTO.EndDate,
                classDTO.CourseId,
                classDTO.TeacherId
            });

            return await _connection.ExecuteAsync(query, parameters) > 0;


        }
    }
}


