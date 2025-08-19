using api.Entities;
using api.Models;

namespace api.Services
{
    public interface IAuthService
    {
        public Task<User?> RegisterAsync(UserDto request);
        public Task<string?> LoginAsync(UserDto request);
    }
}
