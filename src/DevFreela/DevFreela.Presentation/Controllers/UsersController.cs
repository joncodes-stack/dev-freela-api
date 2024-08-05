using DevFreela.Presentation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.Presentation.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpPost()]
        public IActionResult Post(int id)
        {
            return Ok();
        }

        [HttpPut("{id}/profile-picture")]
        public IActionResult PpostProfilePicture(IFormFile file)
        {
            var description = $"File: {file.FileName}, Size {file.Length}";

            return Ok(description);
        }
    }
}
