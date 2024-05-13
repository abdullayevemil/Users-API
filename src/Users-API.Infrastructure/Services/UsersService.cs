namespace Users_API.Infrastructure.Services;

using System.Threading.Tasks;
using Users_API.Core.Models;
using Users_API.Core.Repositories;
using Users_API.Core.Services;

public class UsersService : IUsersService
{
    private readonly IUsersRepository usersRepository;

    public UsersService(IUsersRepository usersRepository)
    {
        this.usersRepository = usersRepository;
    }

    public async Task<User> GetUserByIdAsync(int? userId)
    {
        ArgumentNullException.ThrowIfNull(userId, nameof(userId));

        var user = await usersRepository.GetUserByIdAsync((int)userId);

        return user;
    }
}