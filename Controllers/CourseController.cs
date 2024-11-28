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

    public class CourseController : ControllerBase
    {

        private readonly ICourseRepository _courseRepository;



        public CourseController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;


        }

        [HttpGet("get-by-filter")]
        public async Task<IActionResult> GetAll(string? name, int page = 1, int pageSize = 10)
        {
            try
            {
                var results = await _courseRepository.GetByPageAndFilterAsync(name, page, pageSize);
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
                var results = await _courseRepository.CountAllAsync();
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

        [HttpGet("get-by-id/{courseId}")]
        public async Task<IActionResult> GetById(int courseId)
        {
            try
            {
                var result = await _courseRepository.GetByIdAsync(courseId);
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

        [HttpPost("create-course")]
        public async Task<IActionResult> Create([FromBody] DTOs.Course.CreateCourseDTO courseDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _courseRepository.CreateAsync(courseDTO);
                return Ok(
                    new
                    {
                        message = "Create course success",
                    }
                );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{courseId}")]
        public async Task<IActionResult> Update(int courseId, [FromBody] DTOs.Course.UpdateCourseDTO updateCourseDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _courseRepository.UpdateAsync(courseId, updateCourseDTO);
                return Ok(
                    new
                    {
                        message = "Update course success",
                    }
                );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{courseId}")]
        public async Task<IActionResult> Delete(int courseId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _courseRepository.DeleteAsync(courseId);
                return Ok(
                    new
                    {
                        message = "Delete course success",
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