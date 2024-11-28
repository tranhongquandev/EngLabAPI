using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Asp.Versioning;
using Dapper;
using EngLabAPI.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using BCrypt.Net;
using EngLabAPI.DTOs.Staff;
using EngLabAPI.DTOs;

namespace EngLabAPI.Controllers
{
    [ApiVersion(1)]
    [ApiController]
    [Route("api/v{v:apiVersion}/[controller]")]
    public class AuthController : ControllerBase
    {

        private readonly IDbConnection _connection;

        public AuthController(IDbConnection connection)
        {
            _connection = connection;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            var user = await _connection.QueryFirstOrDefaultAsync<Staff>(
            "SELECT * FROM Staff WHERE Email = @Email",
            new { loginDTO.Email });


            if (user == null)
            {
                return Unauthorized(new { Message = "Invalid email or password" });
            }

            if (!BCrypt.Net.BCrypt.Verify(loginDTO.Password, user.PasswordHash))
            {
                return Unauthorized(new { Message = "Invalid email or password" });
            }

            HttpContext.Session.SetString("UserId", user.Id.ToString());
            HttpContext.Session.SetString("Email", user.Id.ToString());

            return Ok(new { Message = "Logged in successfully" });
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return Ok(new { Message = "Logged out successfully" });
        }

        [HttpGet("me")]
        public async Task<IActionResult> GetMe()
        {
            var userId = HttpContext.Session.GetString("UserId");

            if (userId == null)
            {
                return Unauthorized(new { Message = "You are not logged in" });
            }

            var user = await _connection.QueryFirstOrDefaultAsync<GetStaffDTO>(
                @"SELECT * 
                    FROM Users u
                    INNER JOIN Roles r ON u.RoleId = r.Id
                    WHERE u.Id = @Id",
                new { Id = userId });

            return Ok(user);
        }

    }
}