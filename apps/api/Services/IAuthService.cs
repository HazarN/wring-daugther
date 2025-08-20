using api.Entities;
using api.Models;

namespace api.Services
{
    public interface IAuthService
    {
        public Task<User?> RegisterAsync(UserDto request);
        public Task<TokenResponseDto?> LoginAsync(LoginRequestDto request);
        public Task<TokenResponseDto?> RefreshTokensAsync(RefreshTokenRequestDto request);
    }
}
