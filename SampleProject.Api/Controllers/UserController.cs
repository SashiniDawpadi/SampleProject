using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleProject.Model;
using SampleProject.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace SampleProject.Api.Controllers
{
    [Route("api/SampleProject/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        IUserRepository _repository;

        public IActionResult Index()
        {
            return View();
        }

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }


        [HttpGet("Select")]
        public async Task<ActionResult> SelectValidUser(string UserName, string NICNo)
        {
            var response = await _repository.SelectValidUser( UserName,NICNo);

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