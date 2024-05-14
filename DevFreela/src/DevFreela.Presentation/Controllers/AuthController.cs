using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.Presentation.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("{id}/login")]
        public IActionResult Login(LoginMOdel login)
        {
            return NoContent();
        }
    }
}
