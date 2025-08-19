using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController() : ControllerBase
    {
        [HttpPost("register")]
        public async Task<ActionResult> Register()
        {
            throw new NotImplementedException();
        }
    }
}
