using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.Versioning;
using AutoMapper;
using EngLabAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace EngLabAPI.Controllers
{
    [ApiVersion(1)]
    [ApiController]
    [Route("api/v{v:apiVersion}/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepostory _studentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StudentController(IStudentRepostory studentRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var results = await _studentRepository.GetAllAsync();
                return Ok(_mapper.Map<IEnumerable<DTOs.Student.GetStudentDTO>>(results));
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

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _studentRepository.GetByIdAsync(id);
                return Ok(_mapper.Map<DTOs.Student.GetStudentDTO>(result));
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
                var results = await _studentRepository.GetByPageAsync(page, pageSize);
                return Ok(_mapper.Map<IEnumerable<DTOs.Student.GetStudentDTO>>(results));
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
                var results = await _studentRepository.FindAsync(x => x.FullName!.Contains(name));
                return Ok(_mapper.Map<IEnumerable<DTOs.Student.GetStudentDTO>>(results));
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
        public async Task<IActionResult> Create([FromBody] DTOs.Student.CreateStudentDTO studentDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var entity = _mapper.Map<Model.Entities.Student>(studentDTO);
                _studentRepository.Add(entity);
                await _unitOfWork.SaveChangeAsync();
                return Ok(
                    new
                    {
                        message = "Create student success",

                    }
                );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] DTOs.Student.UpdateStudentDTO studentDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var entity = _mapper.Map<Model.Entities.Student>(studentDTO);
                _studentRepository.Update(entity);
                await _unitOfWork.SaveChangeAsync();
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

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DTOs.Student.DeleteStudentDTO studentDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var entity = _mapper.Map<Model.Entities.Student>(studentDTO);
                _studentRepository.Remove(entity);
                await _unitOfWork.SaveChangeAsync();
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