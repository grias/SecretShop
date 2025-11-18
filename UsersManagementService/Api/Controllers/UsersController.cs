using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using InnoShop.UsersManagementService.Application.Interfaces.Services;

namespace InnoShop.UsersManagementService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserManagementService _userService;

    public UsersController(IUserManagementService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var users = await _userService.GetAllAsync();
        return Ok(users);
    }
}
