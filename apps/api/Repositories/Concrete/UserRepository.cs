using Microsoft.EntityFrameworkCore;

using api.Data;
using api.Entities;
using api.Repositories.Abstract;

namespace api.Repositories.Concrete
{
    public class UserRepository(AppDbContext context) : IUserRepository
    {
        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await context.Users.ToListAsync();
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await context.Users.FindAsync(id);
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task CreateUserAsync(User user)
        {
            context.Users.Add(user);
            await context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            context.Users.Update(user);
            await context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await GetUserByIdAsync(id);

            if (user != null)
            {
                context.Users.Remove(user);
                await context.SaveChangesAsync();
            }
        }

        public async Task<bool> AnyUserWithUsernameAsync(string username)
        {
            return await context.Users.AnyAsync(u => u.Username == username);
        }
    }
}
