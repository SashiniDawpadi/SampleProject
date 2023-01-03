using System.Threading.Tasks;
using SampleProject.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Runtime.Versioning;
using System;
using SampleProject.Model;

namespace SampleProject.Api.Controllers
{
    [Route("api/SampleProject/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        IStudentRepository _repository;

        public IActionResult Index()
        {
            return View();
        }

        public StudentController(IStudentRepository repository)
        {
            _repository = repository;
        }


        [HttpGet("SelectById")]
        public async Task<ActionResult> SelectById(string StudentId)
        {
            var response = await _repository.SelectById(StudentId);

            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }



        [HttpGet("SelectAllStudents")]
        public async Task<ActionResult> SelectAllStudents()
        {
            var response = await _repository.SelectAllStudents();

            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        [HttpDelete("DeleteStudent")]
        public async Task<ActionResult> DeleteStudent(string StudentId)
        {
           
            var response = await _repository.DeleteStudent(StudentId);
     

            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }


        [HttpPost("AddStudent")]
        public async Task<ActionResult> AddStudent( [FromBody] Student student)
        {

            var response = await _repository.AddStudent(student);

            if (response.Success)
            {
                return StatusCode(StatusCodes.Status201Created, response);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }


        [HttpPut("UpdateStudent")]
        public async Task<ActionResult> UpdateStudent( string studentId , [FromBody] Student studentDeails)
        {

            var response = await _repository.UpdateStudent(studentId , studentDeails);

            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }




    }
}