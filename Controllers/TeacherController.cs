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
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TeacherController(ITeacherRepository teacherRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _teacherRepository = teacherRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("get-by-filter")]
        public async Task<IActionResult> GetAll(string? name, int page = 1, int pageSize = 10)
        {
            try
            {
                var results = await _teacherRepository.GetByPageAndFilterAsync(name, page, pageSize);
                return Ok(_mapper.Map<IEnumerable<DTOs.Teacher.GetTeacherDTO>>(results));
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

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _teacherRepository.GetByIdAsync(id);
                return Ok(_mapper.Map<DTOs.Teacher.GetTeacherDTO>(result));
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
        public async Task<IActionResult> Create([FromBody] DTOs.Teacher.CreateTeacherDTO teacherDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var entity = _mapper.Map<Model.Entities.Teacher>(teacherDTO);
                _teacherRepository.Add(entity);
                await _unitOfWork.SaveChangeAsync();
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

        [HttpPatch]
        public async Task<IActionResult> Update([FromBody] DTOs.Teacher.UpdateTeacherDTO teacherDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var entity = _mapper.Map<Model.Entities.Teacher>(teacherDTO);
                _teacherRepository.Update(entity);
                await _unitOfWork.SaveChangeAsync();
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

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DTOs.Teacher.DeleteTeacherDTO teacherDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var entity = _mapper.Map<Model.Entities.Teacher>(teacherDTO);
                _teacherRepository.Remove(entity);
                await _unitOfWork.SaveChangeAsync();
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