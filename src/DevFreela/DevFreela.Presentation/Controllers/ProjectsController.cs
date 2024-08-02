using DevFreela.Presentation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.Presentation.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(string query)
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post(CreateProjectModel project)
        {
            return CreatedAtAction(nameof(GetById), new { id = 1 }, project);
        }

        [HttpPut]
        public IActionResult Put(int id, UpdateProjectModel project)
        {
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }

        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            return NoContent();
        }

        [HttpPut("{id}/complete")]
        public IActionResult Finish(int id)
        {
            return NoContent();
        }


        [HttpPost("{id}/comments")]
        public IActionResult PostComment(int id, cr project)
        {
            return NoContent();
        }
    }
}
