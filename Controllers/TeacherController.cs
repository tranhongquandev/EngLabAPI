using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.Versioning;
using EngLabAPI.Queries.Teacher;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EngLabAPI.Controllers
{
    [ApiVersion(1)]
    [ApiController]
    [Route("api/v{v:apiVersion}/[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly ISender _sender;

        public TeacherController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        [MapToApiVersion(1)]
        [Route("get-by-page")]
        public async Task<IActionResult> GetTeacherByPage([FromQuery] GetTeacherByPageQuery query)
        {
            try
            {
                var teachers = await _sender.Send(query);
                return Ok(teachers);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        [MapToApiVersion(1)]
        [Route("count-all")]
        public async Task<IActionResult> CountAllTeacher()
        {

            var teachers = await _sender.Send(new CountAllTeacherQuery());
            return Ok(teachers);

        }
    }
}