using Microsoft.EntityFrameworkCore;
using MinimalWebApi.Database;
using MinimalWebApi.Models;
namespace MinimalWebApi.Repositories;

public class UserRepository : IUserRepository
{
    private readonly UsersDbContext _dbContext;

    public UserRepository(UsersDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(User user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user));
        }

        await _dbContext.AddAsync(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(User user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user));
        }

        _dbContext.Remove(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _dbContext.Users.ToListAsync();
    }

    public async Task<User> GetByIdAsync(int id)
    {
        return await _dbContext.Users.FindAsync(id) ?? throw new ArgumentNullException("User");
    }

    public async Task<User> GetUserByUsernameAsync(string username)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(u => u.UserName == username) ?? throw new ArgumentNullException("User");
    }

    public async Task UpdateAsync(User user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user));
        }

        _dbContext.Set<User>().Update(user);
        await _dbContext.SaveChangesAsync();
    }
    
    public async Task<bool> ValidateUserCredentialsAsync(string username, string password)
    {
        return await _dbContext.Users
            .FirstOrDefaultAsync(u => u.UserName == username && u.Password == password) != null;
    }
}