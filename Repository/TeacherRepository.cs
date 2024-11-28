using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using EngLabAPI.DTOs.Class;
using EngLabAPI.DTOs.Teacher;
using EngLabAPI.Model.Entities;
using Microsoft.AspNetCore.Mvc;


namespace EngLabAPI.Repository
{
    public class TeacherRepository : ITeacherRepository
    {

        private readonly IDbConnection _connection;

        public TeacherRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> CountAllAsync()
        {
            var query = @"SELECT COUNT(Id) FROM Teacher";

            return await _connection.QueryFirstOrDefaultAsync<int>(query);
        }

        public async Task<bool> CreateAsync(CreateTeacherDTO teacher)
        {
            var query = @"
                INSERT INTO Teacher (TeacherCode, FullName, Gender, Email, PhoneNumber, Address, DateOfBirth, HireDate, EndDate, IsActive)
                VALUES (@TeacherCode, @FullName, @Gender, @Email, @PhoneNumber, @Address, @DateOfBirth, @HireDate, @EndDate, @IsActive) 
            ";
            return await _connection.ExecuteAsync(query, teacher) > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var query = @"
                DELETE FROM Teacher
                WHERE Id = @Id";
            return await _connection.ExecuteAsync(query, new { Id = id }) > 0;
        }

        public async Task<Teacher> GetByIdAsync(int id)
        {
            var query = @"
                SELECT * FROM Teacher
                WHERE Id = @Id";
            return await _connection.QueryFirstOrDefaultAsync<Teacher>(query, new { Id = id }) ?? throw new KeyNotFoundException("Không tìm thấy giáo viên");
        }

        public async Task<IEnumerable<Teacher>> GetByPageAndFilterAsync(string? name, int page, int pageSize)
        {
            var query = @"
                SELECT * FROM Teacher
                WHERE FullName IS NULL OR LIKE @Name
                ORDER BY Id
                OFFSET @Offset ROWS
                FETCH NEXT @PageSize ROWS ONLY";
            return await _connection.QueryAsync<Teacher>(query, new { Name = $"%{name}%", Offset = (page - 1) * pageSize, PageSize = pageSize });
        }

        public async Task<bool> UpdateAsync(int id, UpdateTeacherDTO teacher)
        {
            var query = @"
                UPDATE Teachers
                SET 
                    TeacherCode = COALESCE(@TeacherCode, TeacherCode),
                    FullName = COALESCE(@FullName, FullName),
                    Gender = COALESCE(@Gender, Gender),
                    Email = COALESCE(@Email, Email),
                    PhoneNumber = COALESCE(@PhoneNumber, PhoneNumber),
                    Address = COALESCE(@Address, Address),
                    DateOfBirth = COALESCE(@DateOfBirth, DateOfBirth),
                    HireDate = COALESCE(@HireDate, HireDate),
                    EndDate = COALESCE(@EndDate, EndDate),
                    IsActive = COALESCE(@IsActive, IsActive)
                WHERE Id = @Id;";

            var parameters = new DynamicParameters(new
            {
                Id = id,
                teacher.TeacherCode,
                teacher.FullName,
                teacher.Gender,
                teacher.Email,
                teacher.PhoneNumber,
                teacher.Address,
                teacher.DateOfBirth,
                teacher.HireDate,
                teacher.EndDate,
                teacher.IsActive
            });
            return await _connection.ExecuteAsync(query, parameters) > 0;
        }
    }

}