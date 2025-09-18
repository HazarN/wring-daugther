using api.Entities;
using api.Repositories;

namespace api.Services
{
    public class UserService(IUserRepository userRepository) : IUserService
    {

        public async Task<List<User>> GetUsersAsync()
        {
            var users = await userRepository.GetUsersAsync();
            return users;
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            var user = await userRepository.GetUserByIdAsync(id);
            return user;
        }

        public async Task CreateUserAsync(User user)
        {
            await userRepository.CreateUserAsync(user);
        }

        public async Task UpdateUserAsync(User user)
        {
            await userRepository.UpdateUserAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            await userRepository.DeleteUserAsync(id);
        }
    }
}
