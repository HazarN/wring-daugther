using api.Entities;
using api.Models;

namespace api.Services
{
    public class AuthService : IAuthService
    {
        public Task<User?> RegisterAsync(UserDto request)
        {
            throw new NotImplementedException();
        }

        public Task<string?> LoginAsync(UserDto request)
        {
            throw new NotImplementedException();
        }
    }
}
