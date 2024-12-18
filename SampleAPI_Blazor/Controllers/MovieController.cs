using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleAPI_Blazor.Models;
using SampleAPI_Blazor.Services;

namespace SampleAPI_Blazor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController(MovieService _movieRepo) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_movieRepo.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_movieRepo.GetById(id));
        }

        [HttpPost]
        public IActionResult Create(MovieDTO movieDTO)
        {
            _movieRepo.Add(movieDTO);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _movieRepo.Delete(id);
            return Ok();
        }
    }
}
