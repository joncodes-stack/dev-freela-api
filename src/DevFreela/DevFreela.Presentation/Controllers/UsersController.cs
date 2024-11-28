using DevFreela.Aplication.Commands.Users.InsertUser;
using DevFreela.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.Presentation.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost()]
        public async Task<IActionResult> Post(InsertUserCommand model)
        {
            var result = await _mediator.Send(model);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Data);
        }

        [HttpPost("{id}/skills")]
        public IActionResult PostSkills(CreateUserInputModel model)
        {
            return NoContent();
        }

        [HttpPut("{id}/profile-picture")]
        public IActionResult PostProfilePicture(IFormFile file)
        {
            var description = $"File: {file.FileName}, Size {file.Length}";

            return Ok(description);
        }
    }
}
