using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using EngLabAPI.DTOs.Staff;
using EngLabAPI.Model.Entities;

namespace EngLabAPI.Repository
{
    public class StaffRepository : IStaffRepository
    {
        private readonly IDbConnection _connection;

        public StaffRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> CountAllAsync()
        {
            var query = @"SELECT COUNT(Id) FROM Staff";

            return await _connection.QueryFirstOrDefaultAsync<int>(query);
        }

        public async Task<bool> CreateAsync(CreateStaffDTO staffDTO)
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(staffDTO.Password);
            var query = @"INSERT INTO Staff (StaffCode, FullName, Gender, Email, PasswordHash, PhoneNumber, Address, DateOfBirth, HireDate, EndDate, IsActive, RoleId)
                 VALUES (@StaffCode, @FullName, @Gender, @Email, @PasswordHash, @PhoneNumber, @Address, @DateOfBirth, @HireDate, @EndDate, @IsActive, @RoleId)";

            var parameters = new DynamicParameters(staffDTO);
            parameters.Add("PasswordHash", hashedPassword);

            return await _connection.ExecuteAsync(query, parameters) > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var query = @"DELETE FROM Staff WHERE Id = @Id";

            return await _connection.ExecuteAsync(query, new { Id = id }) > 0;
        }

        public async Task<GetStaffDTO> GetByIdAsync(int id)
        {
            var query = @"SELECT 
                            s.Id, s.StaffCode , s.FullName, s.Gender, s.Email, s.PhoneNumber, s.Address, s.DateOfBirth, s.HireDate,
                            s.EndDate, s.IsActive, s.RoleId, sr.RoleName, sr.Rank
                        FROM Staff s
                        INNER JOIN StaffRole sr ON s.RoleId = sr.Id
                        WHERE s.Id = @Id";

            return await _connection.QueryFirstOrDefaultAsync<GetStaffDTO>(query, new { Id = id }) ?? throw new Exception("Staff not found");
        }

        public Task<IEnumerable<GetStaffDTO>> GetByPageAndFilterAsync(string? name, int page, int pageSize)
        {
            var query = @"SELECT * 
                        FROM Staff s
                        INNER JOIN StaffRole sr ON s.RoleId = sr.Id
                        WHERE s.Name IS NULL OR s.Name LIKE @Name
                        ORDER BY s.Name
                        OFFSET @Offset ROWS
                        FETCH NEXT @PageSize ROWS ONLY";

            return _connection.QueryAsync<GetStaffDTO>(query, new { Name = $"%{name}%", Offset = (page - 1) * pageSize, PageSize = pageSize });
        }

        public async Task<bool> UpdateAsync(int id, UpdateStaffDTO staffDTO)
        {
            var query = @"UPDATE Staff
                 SET StaffCode = COALESCE(@StaffCode, StaffCode),
                     FullName = COALESCE(@FullName, FullName),
                     Gender = COALESCE(@Gender, Gender),
                     Email = COALESCE(@Email, Email),
                     PasswordHash = COALESCE(@PasswordHash, PasswordHash),
                     PhoneNumber = COALESCE(@PhoneNumber, PhoneNumber),
                     Address = COALESCE(@Address, Address),
                     DateOfBirth = COALESCE(@DateOfBirth, DateOfBirth),
                     HireDate = COALESCE(@HireDate, HireDate),
                     EndDate = COALESCE(@EndDate, EndDate),
                     IsActive = COALESCE(@IsActive, IsActive),
                     RoleId = COALESCE(@RoleId, RoleId)
                 WHERE Id = @Id";

            var parameters = new DynamicParameters(staffDTO);
            parameters.Add("Id", id);

            return await _connection.ExecuteAsync(query, parameters) > 0;
        }

        public async Task<IEnumerable<StaffRole>> GetAllRolesAsync()
        {
            var query = @"SELECT * FROM StaffRole";

            return await _connection.QueryAsync<StaffRole>(query);
        }

    }
}
