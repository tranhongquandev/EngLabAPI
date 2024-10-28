using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.Versioning;
using AutoMapper;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClassController(IClassRepository classRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _classRepository = classRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var results = await _classRepository.GetAllAsync();
                return Ok(_mapper.Map<IEnumerable<DTOs.Class.GetClassDTO>>(results));
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
                var result = await _classRepository.GetByIdAsync(id);
                return Ok(_mapper.Map<DTOs.Class.GetClassDTO>(result));
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
                var results = await _classRepository.GetByPageAsync(page, pageSize);
                return Ok(_mapper.Map<IEnumerable<DTOs.Class.GetClassDTO>>(results));
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
                var results = await _classRepository.FindAsync(x => x.ClassCode!.Contains(name) || x.ClassName!.Contains(name));
                return Ok(_mapper.Map<IEnumerable<DTOs.Class.GetClassDTO>>(results));
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
        public async Task<IActionResult> Create([FromBody] DTOs.Class.CreateClassDTO create)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var entity = _mapper.Map<Model.Entities.Class>(create);
                _classRepository.Add(entity);
                await _unitOfWork.SaveChangeAsync();
                return Ok(
                    new
                    {
                        message = "Create class success",

                    }
                );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] DTOs.Class.UpdateClassDTO updateClassDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var entity = _mapper.Map<Model.Entities.Class>(updateClassDTO);
                _classRepository.Update(entity);
                await _unitOfWork.SaveChangeAsync();
                return Ok(
                    new
                    {
                        message = "Update class success",

                    }
                );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DTOs.Class.DeleteClassDTO deleteClassDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var entity = _mapper.Map<Model.Entities.Class>(deleteClassDTO);
                _classRepository.Remove(entity);
                await _unitOfWork.SaveChangeAsync();
                return Ok(
                    new
                    {
                        message = "Delete class success",

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