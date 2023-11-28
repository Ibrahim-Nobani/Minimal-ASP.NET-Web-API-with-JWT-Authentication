using MinimalWebApi.Models;
namespace MinimalWebApi.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<bool> ValidateUserCredentialsAsync(string username, string password);
    Task<User> GetUserByUsernameAsync(string username);
}