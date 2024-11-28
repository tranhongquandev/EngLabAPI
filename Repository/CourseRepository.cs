using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using EngLabAPI.DTOs.Course;

using EngLabAPI.Model.Entities;


namespace EngLabAPI.Repository
{
    public class CourseRepository : ICourseRepository
    {

        private readonly IDbConnection _connection;

        public CourseRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public async Task<int> CountAllAsync()
        {
            var query = "SELECT COUNT(Id) FROM Course";

            return await _connection.QueryFirstOrDefaultAsync<int>(query);
        }

        public async Task<bool> CreateAsync(CreateCourseDTO courseDTO)
        {
            var query = @"INSERT INTO Course (CourseCode, CourseName, Description, Duration, Fee, Discount, TotalFee, IsActive, CreatedDate, UpdatedDate, LevelId)
                        VALUES (@CourseCode, @CourseName, @Description, @Duration, @Fee, @Discount, @TotalFee, @IsActive, @CreatedDate, @UpdatedDate, @LevelId)";

            return await _connection.ExecuteAsync(query, courseDTO) > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var query = @"DELETE FROM Course WHERE Id = @Id";

            return await _connection.ExecuteAsync(query, new { Id = id }) > 0;
        }

        public async Task<GetCourseDTO> GetByIdAsync(int id)
        {
            var query = @"SELECT *
            FROM Course c
            INNER JOIN Level l ON c.LevelId = l.Id
            WHERE Id = @Id";

            return await _connection.QueryFirstOrDefaultAsync<GetCourseDTO>(query, new { Id = id }) ?? throw new KeyNotFoundException("Không tìm thấy khóa học");
        }

        public async Task<IEnumerable<GetCourseDTO>> GetByPageAndFilterAsync(string? name, int page, int pageSize)
        {
            var query = @"
                            SELECT * 
                            FROM Course c
                            INNER JOIN Level l ON c.LevelId = l.Id
                            WHERE c.CourseName IS NULL OR c.CourseName LIKE CONCAT('%', @name, '%')
                            ORDER BY c.Id
                            OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY
                            ";
            return await _connection.QueryAsync<GetCourseDTO>(query, new { name, Offset = (page - 1) * pageSize, PageSize = pageSize });
        }

        public async Task<bool> UpdateAsync(int id, UpdateCourseDTO courseDTO)
        {
            var query = @"UPDATE Course
                        SET CourseCode = COALESCE(@CourseCode, CourseCode),
                            CourseName = COALESCE(@CourseName, CourseName),
                            Description = COALESCE(@Description, Description),
                            Duration = COALESCE(@Duration, Duration),
                            Fee = COALESCE(@Fee, Fee),
                            Discount = COALESCE(@Discount, Discount),
                            TotalFee = COALESCE(@TotalFee, TotalFee),
                            IsActive = COALESCE(@IsActive, IsActive),
                            UpdatedDate = COALESCE(@UpdatedDate, UpdatedDate),
                            LevelId = COALESCE(@LevelId, LevelId)
                        WHERE Id = @Id";

            var parameters = new DynamicParameters(new
            {
                courseDTO.CourseCode,
                courseDTO.CourseName,
                courseDTO.Description,
                courseDTO.Duration,
                courseDTO.Fee,
                courseDTO.Discount,
                courseDTO.TotalFee,
                courseDTO.IsActive,
                courseDTO.LevelId,
                Id = id
            });

            return await _connection.ExecuteAsync(query, parameters) > 0;
        }
    }
}
