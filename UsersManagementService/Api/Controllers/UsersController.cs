using InnoShop.UsersManagementService.Application.Commands;
using InnoShop.UsersManagementService.Application.Dtos.Requests;
using InnoShop.UsersManagementService.Application.Dtos.Responses;
using InnoShop.UsersManagementService.Application.Queries;
using InnoShop.UsersManagementService.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InnoShop.UsersManagementService.Api.Controllers;

[Route("api/[controller]")]
[Authorize(Roles = "Admin")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<UserDto>>> GetAll([FromQuery] UserQueryObject queryObject)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var books = await _mediator.Send(new GetAllUsersQuery(queryObject));
        return Ok(books);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<UserDto>> GetById([FromRoute] int id)
    {
        var product = await _mediator.Send(new GetUserByIdQuery(id));

        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult<UserDto>> Create([FromBody] CreateUserDto productDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdUser = await _mediator.Send(new CreateUserCommand(productDto));

        return Ok(createdUser);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<UserDto>> Update([FromRoute] int id, [FromBody] UpdateUserDto productDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var updatedUser = await _mediator.Send(new UpdateUserCommand(id, productDto));

        return Ok(updatedUser);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteById([FromRoute] int id)
    {
        await _mediator.Send(new DeleteUserCommand(id));

        return NoContent();
    }
}
