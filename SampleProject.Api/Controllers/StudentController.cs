using System.Threading.Tasks;
using SampleProject.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

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
    }
}