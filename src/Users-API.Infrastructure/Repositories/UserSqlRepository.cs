namespace Users_API.Infrastructure.Repositories;

using System.Net.Http.Json;
using System.Threading.Tasks;
using Users_API.Core.Models;
using Users_API.Core.Repositories;
using Users_API.Infrastructure.Data;

public class UserSqlRepository : IUsersRepository
{
    private readonly LibraryDbContext dbContext;

    public UserSqlRepository(LibraryDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<User> GetUserByIdAsync(int userId)
    {
        var searchedUser = dbContext.Users.FirstOrDefault(user => user.Id == userId); 

        var booksIds = dbContext.UsersBooks.Where(userBook => userBook.UserId == userId);

        HttpClient client = new HttpClient();

        var books = new Book[]{};

        foreach (var bookId in booksIds)
        {
            var book = await client.GetFromJsonAsync<Book>($"http://localhost:8080/api/Books/GetBook/{bookId}");

            books.Append(book);
        }

        searchedUser!.Books = books;
        
        return searchedUser;
    }
}