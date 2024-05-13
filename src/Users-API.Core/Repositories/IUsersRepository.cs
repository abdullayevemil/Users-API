namespace Users_API.Core.Repositories;

using Users_API.Core.Models;

public interface IUsersRepository
{
    Task<User> GetUserByIdAsync(int userId);
}