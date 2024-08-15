using DevFreela.Application.Models;
using DevFreela.InfraSctructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;


namespace DevFreela.Presentation.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly DevFreelaDbContext _context;

        public ProjectsController(DevFreelaDbContext context)
        {
                _context = context;
        }

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
        public IActionResult Post(CreateProjectInputModel project)
        {
            return CreatedAtAction(nameof(GetById), new { id = 1 }, project);
        }

        [HttpPut]
        public IActionResult Put(int id, UpdateProjectInputModel project)
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
        public IActionResult PostComment(int id, CreateProjectCommentInputModel project)
        {
            return NoContent();
        }
    }
}
