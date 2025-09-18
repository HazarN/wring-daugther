using api.Entities;
using api.Models;

namespace api.Services.Abstract
{
    public interface IAuthService
    {
        public Task<User?> RegisterAsync(UserDto request);
        public Task<TokenResponseDto?> LoginAsync(LoginRequestDto request);
        public Task<bool> LogoutAsync(int userId);
        public Task<TokenResponseDto?> RefreshTokensAsync(RefreshTokenRequestDto request);
        public Task<UserResponseDto?> GetAuthUserAsync(int userId);
    }
}
