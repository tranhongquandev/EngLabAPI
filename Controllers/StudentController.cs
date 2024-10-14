using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.Versioning;
using EngLabAPI.Command.Student;
using EngLabAPI.Queries.Student;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace EngLabAPI.Controllers
{
    [ApiVersion(1)]
    [ApiController]
    [Route("api/v{v:apiVersion}/[controller]")]
    public class StudentController : ControllerBase
    {
        private ISender _sender;

        public StudentController(ISender sender)
        {
            _sender = sender;
        }


        /// <summary>
        /// Get all student by page
        /// </summary>
        /// <param name="query"></param>
        /// <returns>Return all student beetwen (page-1) * pagesize</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET api/v1/student/get-by-page?page=1&amp;pagesize=10
        /// 
        /// </remarks>
        /// <response code="200">Returns all student beetwen (page-1) * pagesize</response>
        /// <response code="404">If the item is null</response>
        [HttpGet]
        [MapToApiVersion(1)]
        [Route("get-by-page")]
        public async Task<IActionResult> GetStudentByPage([FromQuery] GetStudentByPageQuery query)
        {

            try
            {
                var students = await _sender.Send(query);
                return Ok(students);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }


        /// <summary>
        /// Count all student 
        /// </summary>
        /// <returns>Return number of student in database</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET api/v1/student/count-all
        /// 
        /// </remarks>
        /// <response code="200">Return number of student in database</response>
        [HttpGet]
        [MapToApiVersion(1)]
        [Route("count-all")]
        public async Task<IActionResult> CountAllStudent()
        {
            var count = await _sender.Send(new CountAllStudentQuery());
            return Ok(count);
        }

         /// <summary>
        /// Get student by name
        /// </summary>
        /// <returns>Return number of student in database</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET api/v1/student/get-by-name?name=John
        /// 
        /// </remarks>
        /// <response code="200">Return number of student in database</response>
        [HttpGet]
        [MapToApiVersion(1)]
        [Route("get-by-name")]
        public async Task<IActionResult> GetByName([FromQuery] GetStudentByNameQuery query)
        {

            try
            {
                 var result = await _sender.Send(query);
                 return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                
                return NotFound(ex.Message);
            }
            catch(InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
           
        }


        [HttpPost]
        [MapToApiVersion(1)]
        public async Task<IActionResult> Create([FromBody] CreateStudentCommand command)
        {
            var entity = await _sender.Send(command);
            if (entity == 1) return Ok("Student created successfully");
            return BadRequest("Student created failed");
        }
    }
}