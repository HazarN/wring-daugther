using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using api.Entities;
using api.Services;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController(IUserService userService) : ControllerBase
    {
        [Authorize(Policy = "AdminOnly")]
        [HttpGet]
        public async Task<ActionResult<User>> GetAll()
        {
            var users = await userService.GetUsersAsync();
            return Ok(users);
        }
    }
}
