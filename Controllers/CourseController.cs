using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.Versioning;
using AutoMapper;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CourseController(ICourseRepository courseRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var results = await _courseRepository.GetAllAsync();
                return Ok(_mapper.Map<IEnumerable<DTOs.Course.GetCourseDTO>>(results));
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

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _courseRepository.GetByIdAsync(id);
                return Ok(_mapper.Map<DTOs.Course.GetCourseDTO>(result));
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

        [HttpGet("get-by-page")]
        public async Task<IActionResult> GetByPage(int page, int pageSize)
        {
            try
            {
                var results = await _courseRepository.GetByPageAsync(page, pageSize);
                return Ok(_mapper.Map<IEnumerable<DTOs.Course.GetCourseDTO>>(results));
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

        [HttpGet("get-by-name")]
        public async Task<IActionResult> GetByName([FromQuery] string name)
        {
            try
            {
                var results = await _courseRepository.FindAsync(x => x.CourseName!.Contains(name) || x.CourseCode!.Contains(name));
                return Ok(_mapper.Map<IEnumerable<DTOs.Course.GetCourseDTO>>(results));
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


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DTOs.Course.CreateCourseDTO courseDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var entity = _mapper.Map<Model.Entities.Course>(courseDTO);
                _courseRepository.Add(entity);
                await _unitOfWork.SaveChangeAsync();
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

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] DTOs.Course.UpdateCourseDTO updateCourseDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var entity = _mapper.Map<Model.Entities.Course>(updateCourseDTO);
                _courseRepository.Update(entity);
                await _unitOfWork.SaveChangeAsync();
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

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DTOs.Course.DeleteCourseDTO deleteCourseDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var entity = _mapper.Map<Model.Entities.Course>(deleteCourseDTO);
                _courseRepository.Remove(entity);
                await _unitOfWork.SaveChangeAsync();
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