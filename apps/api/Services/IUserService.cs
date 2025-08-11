using api.Models;

namespace api.Services
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();
        Task<User?> GetUserById(int id);
        Task CreateUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(int id);
    }
}