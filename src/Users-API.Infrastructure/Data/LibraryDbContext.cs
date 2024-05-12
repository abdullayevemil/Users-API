namespace Users_API.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;
using Users_API.Core.Models;

public class LibraryDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<UserBook> UsersBooks { get; set; }

    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }
}