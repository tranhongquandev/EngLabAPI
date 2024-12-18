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

        public async Task<IEnumerable<GetStaffDTO>> GetByPageAndFilterAsync(string? name, int? page, int? pageSize, int userId)
        {
            var queryUserRoleRank = @"SELECT sr.Rank FROM StaffRole sr INNER JOIN Staff s ON s.RoleId = sr.Id WHERE s.Id = @UserId";
            var roleRank = _connection.ExecuteScalar<int>(queryUserRoleRank, new { UserId = userId });

            if (roleRank == 0)
            {
                throw new Exception("User not found");
            }

            var query = "";
            var parameters = new DynamicParameters();


            if (roleRank == 1)
            {
                query = @"
                SELECT * 
                FROM Staff s
                INNER JOIN StaffRole sr ON s.RoleId = sr.Id
                WHERE 1=1
                ";
            }
            else
            {
                query = @"
                SELECT * 
                FROM Staff s
                INNER JOIN StaffRole sr ON s.RoleId = sr.Id
                WHERE sr.Rank > @RoleRank
                ";

                parameters.Add("RoleRank", roleRank);
            }

            if (!string.IsNullOrEmpty(name))
            {
                parameters.Add("@Name", "%" + name + "%");
                query += " AND (@Name IS NULL OR s.FullName LIKE @Name)";
            }

            if (page != null && pageSize != null)
            {
                parameters.Add("Offset", (page - 1) * pageSize);
                parameters.Add("PageSize", pageSize);
                query += @"
                ORDER BY s.FullName 
                OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY
        ";
            }

            return await _connection.QueryAsync<GetStaffDTO>(query, parameters);
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

        public async Task<IEnumerable<StaffRole>> GetAllRolesAsync(int userId)
        {

            var queryUserRoleRank = @"SELECT sr.Rank FROM StaffRole sr INNER JOIN Staff s ON s.RoleId = sr.Id WHERE s.Id = @UserId";

            var roleRank = await _connection.QueryFirstOrDefaultAsync<int>(queryUserRoleRank, new { UserId = userId });

            if (roleRank == 0)
            {
                throw new Exception("User not found");
            }

            var query = "";

            if (roleRank == 1)
            {
                query = @"SELECT * FROM StaffRole";
            }
            else
            {
                query = @"SELECT * FROM StaffRole WHERE Rank > @RoleRank";
            }
            return await _connection.QueryAsync<StaffRole>(query);
        }

    }
}
