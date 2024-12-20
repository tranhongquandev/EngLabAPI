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
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepostory _studentRepository;



        public StudentController(IStudentRepostory studentRepository)
        {
            _studentRepository = studentRepository;


        }

        [HttpGet("get-by-filter")]
        public async Task<IActionResult> GetAll(string? name, int page = 1, int pageSize = 10)
        {
            try
            {
                var results = await _studentRepository.GetByPageAndFilterAsync(name, page, pageSize);
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
                var results = await _studentRepository.CountAllAsync();
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

        [HttpGet("get-by-id/{studentId}")]
        public async Task<IActionResult> GetById(int studentId)
        {
            try
            {
                var result = await _studentRepository.GetByIdAsync(studentId);
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

        [HttpPost("create-student")]
        public async Task<IActionResult> Create([FromBody] DTOs.Student.CreateStudentDTO studentDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _studentRepository.CreateAsync(studentDTO);
                return Ok(new
                {
                    message = "Create student success",
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{studentId}")]
        public async Task<IActionResult> Update(int studentId, [FromBody] DTOs.Student.UpdateStudentDTO studentDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _studentRepository.UpdateAsync(studentId, studentDTO);
                return Ok(
                    new
                    {
                        message = "Update student success",
                    }
                );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{studentId}")]
        public async Task<IActionResult> Delete(int studentId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _studentRepository.DeleteAsync(studentId);
                return Ok(
                    new
                    {
                        message = "Delete student success",
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