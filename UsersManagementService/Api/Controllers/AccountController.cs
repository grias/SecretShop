using InnoShop.UsersManagementService.Api.Dtos.Requests;
using InnoShop.UsersManagementService.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InnoShop.UsersManagementService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private IAuthenticationService _authenticationService;

    public AccountController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpGet]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDtp)
    {
        var token = await _authenticationService.LoginAsync(loginRequestDtp.Username, loginRequestDtp.Password);
        return Ok(token);
    }
}
