using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Users_API.Core.Models;
using Users_API.Core.Repositories;
using Users_API.Core.Services;
using Users_API.Infrastructure.Data;
using Users_API.Infrastructure.Repositories;
using Users_API.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LibraryDbContext>(dbContextOptionsBuilder =>
{
    var connectionString = builder.Configuration.GetConnectionString("LibraryDb");

    dbContextOptionsBuilder.UseNpgsql(connectionString, o =>
    {
        o.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
    });
});

builder.Services.AddScoped<IUsersRepository, UserSqlRepository>();

builder.Services.AddScoped<IUsersService, UsersService>();

var app = builder.Build();

// using (var scope = app.Services.CreateScope())
// {
//     var dbContext = scope.ServiceProvider.GetRequiredService<LibraryDbContext>();

//     await dbContext.Database.MigrateAsync();

//     await dbContext.Database.EnsureCreatedAsync();

//     await dbContext.Users.AddAsync(new User
//     {
//         Name = "Emil",
//         BirthDate = new DateOnly(2006, 4, 27)
//     });

//     await dbContext.Users.AddAsync(new User
//     {
//         Name = "Bob",
//         BirthDate = new DateOnly(1999, 3, 4)
//     });

//     await dbContext.UsersBooks.AddAsync(new UserBook
//     {
//         UserId = 1,
//         BookId = 1
//     });

//     await dbContext.UsersBooks.AddAsync(new UserBook
//     {
//         UserId = 1,
//         BookId = 2
//     });

//     await dbContext.UsersBooks.AddAsync(new UserBook
//     {
//         UserId = 2,
//         BookId = 2
//     });

//     await dbContext.UsersBooks.AddAsync(new UserBook
//     {
//         UserId = 2,
//         BookId = 3
//     });

//     try
//     {
//         await dbContext.SaveChangesAsync();
//     }
//     catch (Exception ex)
//     {
//         Console.WriteLine(ex.Message);
//     }
// }

app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();