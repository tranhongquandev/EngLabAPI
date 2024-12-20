using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.Versioning;

using EngLabAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EngLabAPI.Controllers
{
    [ApiVersion(1)]
    [ApiController]
    [Route("api/v{v:apiVersion}/[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherRepository _teacherRepository;



        public TeacherController(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;


        }

        [HttpGet("get-by-filter")]
        public async Task<IActionResult> GetAll(string? name, int page = 1, int pageSize = 10)
        {
            try
            {
                var results = await _teacherRepository.GetByPageAndFilterAsync(name, page, pageSize);
                return Ok(results);
            }
            catch (KeyNotFoundException ex)
            {

                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("count-all")]
        public async Task<IActionResult> CountAll()
        {
            try
            {
                var results = await _teacherRepository.CountAllAsync();
                return Ok(results);
            }
            catch (KeyNotFoundException ex)
            {

                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-by-id/{teacherId}")]
        public async Task<IActionResult> GetById(int teacherId)
        {
            try
            {
                var result = await _teacherRepository.GetByIdAsync(teacherId);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("create-teacher")]
        public async Task<IActionResult> Create([FromBody] DTOs.Teacher.CreateTeacherDTO teacherDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _teacherRepository.CreateAsync(teacherDTO);
                return Ok(
                    new
                    {
                        message = "Create teacher success",
                    }
                );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{teacherId}")]
        public async Task<IActionResult> Update(int teacherId, [FromBody] DTOs.Teacher.UpdateTeacherDTO teacherDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _teacherRepository.UpdateAsync(teacherId, teacherDTO);
                return Ok(
                    new
                    {
                        message = "Update teacher success",
                    }
                );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{teacherId}")]
        public async Task<IActionResult> Delete(int teacherId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _teacherRepository.DeleteAsync(teacherId);
                return Ok(
                    new
                    {
                        message = "Delete teacher success",
                    }
                );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}