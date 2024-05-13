namespace Users_API.Presentation.Controllers;

using Users_API.Core.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/[controller]/[action]")]
public class UsersController : ControllerBase
{
    private readonly IUsersService usersService;

    public UsersController(IUsersService usersService)
    {
        this.usersService = usersService;
    }

    [HttpGet]
    [Route("/api/[controller]/[action]/{userId}")]
    public async Task<IActionResult> GetUserAsync(int? userId)
    {
        var user = await this.usersService.GetUserByIdAsync(userId);

        return base.Ok(user);
    }
}