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

        public async Task<TokenResponseDto?> LoginAsync(LoginRequestDto request)
        {
            var user = await userRepository.GetUserByUsernameAsync(request.Username);

            if (user == null) return null;

            bool failedPassword = new PasswordHasher<User>()
                .VerifyHashedPassword(user, user.PasswordHashed, request.Password) == PasswordVerificationResult.Failed;

            if (failedPassword) return null;

            return await CreateTokenResponseDto(user);
        }

        public async Task<TokenResponseDto?> RefreshTokensAsync(RefreshTokenRequestDto request)
        {
            var user = await ValidateRefreshTokenAsync(request.UserId, request.RefreshToken);
            if (user == null)
                return null;

            return await CreateTokenResponseDto(user);
        }

        private async Task<TokenResponseDto?> CreateTokenResponseDto(User user)
        {
            return new TokenResponseDto
            {
                AccessToken = tokenService.CreateAccessToken(user),
                RefreshToken = await SaveRefreshTokenAsync(user)
            };
        }
        private async Task<User?> ValidateRefreshTokenAsync(int userId, string refreshToken)
        {
            var user = await userRepository.GetUserByIdAsync(userId);

            if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryDate <= DateTime.UtcNow)
                return null;

            return user;
        }
        private async Task<string> SaveRefreshTokenAsync(User user)
        {
            var token = tokenService.CreateRefreshToken();

            user.RefreshToken = token;
            user.RefreshTokenExpiryDate = DateTime.UtcNow.AddDays(14);
            await userRepository.SaveAsync();

            return token;
        }
    }
}
