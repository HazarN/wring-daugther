using Microsoft.AspNetCore.Mvc;

using api.Entities;
using api.Services;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService service;

        public UsersController(IUserService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<ActionResult<User>> GetAll()
        {
            var users = await service.GetUsers();
            return Ok(users);
        }
    }
}