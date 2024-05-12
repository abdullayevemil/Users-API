namespace Users_API.Core.Services;

using Users_API.Core.Models;

public interface IUsersService
{
    Task<User> GetUserByIdAsync(int? userId);
}