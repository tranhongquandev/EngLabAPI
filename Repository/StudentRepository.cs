using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using EngLabAPI.DTOs.Student;

using EngLabAPI.Model.Entities;

namespace EngLabAPI.Repository
{
    public class StudentRepository : IStudentRepostory
    {
        private readonly IDbConnection _connection;

        public StudentRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> CountAllAsync()
        {
            var query = @"SELECT COUNT(Id) FROM Student";

            return await _connection.QueryFirstOrDefaultAsync<int>(query);
        }

        public async Task<bool> CreateAsync(CreateStudentDTO studentDTO)
        {
            var query = @"
                INSERT INTO Student (StudentCode, FullName, Gender, Email, PhoneNumber, DateOfBirth,  Status)
                VALUES (@StudentCode, @FullName, @Gender, @Email, @PhoneNumber, @DateOfBirth, @Status)";

            return await _connection.ExecuteAsync(query, studentDTO) > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var query = @"
                DELETE FROM Student
                WHERE Id = @Id";

            return await _connection.ExecuteAsync(query, new { Id = id }) > 0;
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            var query = @"
                SELECT * FROM Student
                WHERE Id = @Id";

            return await _connection.QueryFirstOrDefaultAsync<Student>(query, new { Id = id }) ?? throw new KeyNotFoundException("Không tìm thấy sinh viên");
        }

        public Task<IEnumerable<GetStudentDTO>> GetByPageAndFilterAsync(string? name, int page, int pageSize)
        {
            var query = @"
                SELECT * FROM Student
                WHERE FullName IS NULL OR FullName LIKE CONCAT('%', @Name, '%')
                ORDER BY Id
                OFFSET @Offset ROWS
                FETCH NEXT @PageSize ROWS ONLY";

            return _connection.QueryAsync<GetStudentDTO>(query, new { Name = name, Offset = (page - 1) * pageSize, PageSize = pageSize });
        }

        public async Task<bool> UpdateAsync(int id, UpdateStudentDTO studentDTO)
        {
            var query = @"
                UPDATE Student
                 SET 
                    StudentCode = COALESCE(@StudentCode, StudentCode),
                    FullName = COALESCE(@FullName, FullName),
                    Gender = COALESCE(@Gender, Gender),
                    Email = COALESCE(@Email, Email),
                    PhoneNumber = COALESCE(@PhoneNumber, PhoneNumber),
                    DateOfBirth = COALESCE(@DateOfBirth, DateOfBirth),
                    Status = COALESCE(@Status, Status)
                WHERE Id = @Id;";

            var parameter = new DynamicParameters(new
            {
                Id = id,
                studentDTO.StudentCode,
                studentDTO.FullName,
                studentDTO.Gender,
                studentDTO.Email,
                studentDTO.PhoneNumber,
                studentDTO.DateOfBirth,
                studentDTO.Status
            });

            return await _connection.ExecuteAsync(query, parameter) > 0;
        }
    }
}