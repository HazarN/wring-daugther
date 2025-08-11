using api.Models;
using api.Repositories;

namespace api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public Task<List<User>> GetUsers()
        {
            return userRepository.GetUsersAsync();
        }

        public Task<User?> GetUserById(int id)
        {
            return userRepository.GetUserByIdAsync(id);
        }

        public Task CreateUser(User user)
        {
            return userRepository.CreateUserAsync(user);
        }

        public Task UpdateUser(User user)
        {
            return userRepository.UpdateUserAsync(user);
        }

        public Task DeleteUser(int id)
        {
            return userRepository.DeleteUserAsync(id);
        }
    }
}
