using Microsoft.AspNetCore.Identity;

using api.Entities;
using api.Models;
using api.Repositories;

namespace api.Services
{
    public class AuthService(IUserRepository userRepository, ITokenService tokenService) : IAuthService
    {
        public async Task<User?> RegisterAsync(UserDto request)
        {
            // A user with existent username cannot be registered
            if (await userRepository.AnyUserWithUsernameAsync(request.Username))
                return null;

            // Password will be set after hashing
            var user = new User
            {
                Username = request.Username,
                Email = request.Email,
                PasswordHashed = ""
            };

            var hashedPassword = new PasswordHasher<User>()
                .HashPassword(user, request.Password);

            user.PasswordHashed = hashedPassword;
            if (request.IsAdmin) user.IsAdmin = request.IsAdmin;

            await userRepository.CreateUserAsync(user);
            return user;
        }

        public async Task<string?> LoginAsync(LoginRequestDto request)
        {
            var user = await userRepository.GetUserByUsernameAsync(request.Username);

            if (user == null) return null;

            bool failedPassword = new PasswordHasher<User>()
                .VerifyHashedPassword(user, user.PasswordHashed, request.Password) == PasswordVerificationResult.Failed;

            if (failedPassword) return null;

            return tokenService.CreateAccessToken(user);
        }
    }
}
