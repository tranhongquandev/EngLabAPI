using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.Versioning;
using EngLabAPI.Model.Entities;
using EngLabAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EngLabAPI.Controllers
{

    [ApiVersion(1)]
    [ApiController]
    [Route("api/v{v:apiVersion}/[controller]")]
    public class ClassController : ControllerBase
    {
        private readonly IClassRepository _classRepository;



        public ClassController(IClassRepository classRepository)
        {
            _classRepository = classRepository;


        }

        [HttpGet("get-by-filter")]
        public async Task<IActionResult> GetAll(string? name, int page = 1, int pageSize = 10)
        {
            try
            {
                var results = await _classRepository.GetByPageAndFilterAsync(name, page, pageSize);
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
                var results = await _classRepository.CountAllAsync();
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

        [HttpGet("get-by-id/{classId}")]
        public async Task<IActionResult> GetById(int classId)
        {
            try
            {
                var result = await _classRepository.GetByIdAsync(classId);
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


        [HttpGet("get-student-by-class-id/{classId}")]
        public async Task<IActionResult> GetStudentByClassId(int classId)
        {
            try
            {
                var result = await _classRepository.GetStudenInClassAsync(classId);
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

        [HttpGet("get-student-not-in-class/{classId}")]
        public async Task<IActionResult> GetStudentNotInClass(int classId)
        {
            try
            {
                var result = await _classRepository.GetStudentNotInClassAsync(classId);
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

        [HttpPost("add-student")]
        public async Task<IActionResult> AddStudent(int classId, [FromBody] List<int> studentId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _classRepository.AddStudentAsync(classId, studentId);
                return Ok(
                    new
                    {
                        message = "Add student success",
                        id = result
                    }
                );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("create-class")]
        public async Task<IActionResult> Create([FromBody] DTOs.Class.CreateClassDTO create)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _classRepository.CreateAsync(create);
                return Ok(
                    new
                    {
                        message = "Create class success",
                        id = result
                    }
                );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{classId}")]
        public async Task<IActionResult> Update(int classId, [FromBody] DTOs.Class.UpdateClassDTO updateClassDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _classRepository.UpdateAsync(classId, updateClassDTO);
                return Ok(
                    new
                    {
                        message = "Update class success",
                        id = result
                    }
                );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{classId}")]
        public async Task<IActionResult> Delete(int classId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _classRepository.DeleteAsync(classId);
                return Ok(
                    new
                    {
                        message = "Delete class success",
                        id = result
                    }
                );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("remove-student-in-class")]
        public async Task<IActionResult> DeleteStudent([FromQuery] int classId, [FromQuery] int studentId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _classRepository.RemoveStudentAsync(classId, studentId);
                return Ok(
                    new
                    {
                        message = "Delete student success",
                        id = result
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