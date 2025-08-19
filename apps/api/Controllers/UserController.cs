using Microsoft.AspNetCore.Mvc;

using api.Entities;
using api.Services;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController(IUserService userService) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<User>> GetAll()
        {
            var users = await userService.GetUsers();
            return Ok(users);
        }
    }
}