using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using api.Entities;
using api.Models;
using api.Services.Abstract;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {
            var user = await authService.RegisterAsync(request);
            if (user == null)
                return BadRequest("Username is already exists");

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<TokenResponseDto>> Login(LoginRequestDto request)
        {
            var result = await authService.LoginAsync(request);
            if (result == null)
                return BadRequest("Invalid username or password");

            return Ok(result);
        }

        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "id");
            if (userIdClaim == null)
                return Unauthorized();

            if (!int.TryParse(userIdClaim.Value, out int userId))
                return Unauthorized();

            var success = await authService.LogoutAsync(userId);
            if (!success)
                return NotFound();

            return Ok(new { message = "Logged out successfully" });
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<TokenResponseDto>> RefreshToken(RefreshTokenRequestDto request)
        {
            var result = await authService.RefreshTokensAsync(request);
            if (result == null)
                return Unauthorized("Invalid refresh token");

            return Ok(result);
        }

        [Authorize]
        [HttpGet("me")]
        public async Task<ActionResult<User>> AuthMe()
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "id");
            if (userIdClaim == null)
                return Unauthorized();

            if (!int.TryParse(userIdClaim.Value, out int userId))
                return Unauthorized();

            var authUser = await authService.GetAuthUserAsync(userId);
            if (authUser == null)
                return NotFound();

            return Ok(authUser);
        }
    }
}
