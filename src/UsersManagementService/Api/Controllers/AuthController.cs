using InnoShop.UsersManagementService.Application.Commands;
using InnoShop.UsersManagementService.Application.Dtos.Requests;
using InnoShop.UsersManagementService.Application.Dtos.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InnoShop.UsersManagementService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("login")]
    public async Task<ActionResult<LoginResponseDto>> Login([FromBody] LoginRequestDto request)
    {
        var response = await _mediator.Send(new LoginCommand(request));
        return Ok(response);
    }

    [HttpPost("register")]
    public async Task<ActionResult<RegisterResponseDto>> Register([FromBody] RegisterRequestDto request)
    {
        var response = await _mediator.Send(new RegisterCommand(request));
        return Ok(response);
    }

    [HttpPost("forgot-password")]
    public async Task<ActionResult<RegisterResponseDto>> ForgotPassword([FromBody] RegisterRequestDto request)
    {
        var response = await _mediator.Send(new RegisterCommand(request));
        return Ok(response);
    }
}
