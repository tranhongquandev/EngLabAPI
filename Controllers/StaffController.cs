using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.Versioning;
using EngLabAPI.DTOs.Staff;
using EngLabAPI.Model.Entities;
using EngLabAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EngLabAPI.Controllers
{
    [ApiVersion(1)]
    [ApiController]
    [Route("api/v{v:apiVersion}/[controller]")]
    public class StaffController : ControllerBase
    {
        private readonly IStaffRepository _staffRepository;



        public StaffController(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;


        }

        [HttpGet("get-by-filter")]
        public async Task<IActionResult> GetAll(string? name, int page = 1, int pageSize = 10)
        {
            try
            {
                var results = await _staffRepository.GetByPageAndFilterAsync(name, page, pageSize);
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
                var results = await _staffRepository.CountAllAsync();
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

        [HttpGet("get-by-id/{staffId}")]
        public async Task<IActionResult> GetById(int staffId)
        {
            try
            {
                var result = await _staffRepository.GetByIdAsync(staffId);
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

        [HttpPost("create-staff")]
        public async Task<IActionResult> Create([FromBody] DTOs.Staff.CreateStaffDTO staffDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _staffRepository.CreateAsync(staffDTO);
                return Ok(
                    new
                    {
                        message = "Create staff success",
                    }
                );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{staffId}")]
        public async Task<IActionResult> Update(int staffId, [FromBody] DTOs.Staff.UpdateStaffDTO updateStaffDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _staffRepository.UpdateAsync(staffId, updateStaffDTO);
                return Ok(
                    new
                    {
                        message = "Update staff success",
                    }
                );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{staffId}")]
        public async Task<IActionResult> Delete(int staffId)
        {
            try
            {
                var result = await _staffRepository.DeleteAsync(staffId);
                return Ok(
                    new
                    {
                        message = "Delete staff success",
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