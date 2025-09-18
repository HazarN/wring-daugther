using api.Entities;

namespace api.Repositories.Abstract
{
    public interface IUserRepository
    {
        Task SaveAsync();
        Task<List<User>> GetUsersAsync();
        Task<User?> GetUserByIdAsync(int id);
        Task<User?> GetUserByUsernameAsync(string username);
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
        Task<bool> AnyUserWithUsernameAsync(string username);
    }
}
