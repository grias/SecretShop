using InnoShop.ProductsManagementService.Api.Filters;
using InnoShop.ProductsManagementService.Application.Commands;
using InnoShop.ProductsManagementService.Application.Dtos;
using InnoShop.ProductsManagementService.Application.Dtos.Requests;
using InnoShop.ProductsManagementService.Application.Queries;
using InnoShop.ProductsManagementService.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace InnoShop.ProductsManagementService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<ProductDto>>> GetAll([FromQuery] QueryObject queryObject)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var books = await _mediator.Send(new GetAllProductsQuery(queryObject));
        return Ok(books);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var product = await _mediator.Send(new GetProductByIdQuery(id));

        return Ok(product);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductDto productDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var createdProduct = await _mediator.Send(new CreateProductCommand(int.Parse(userId!), productDto));

        return Ok(createdProduct);
    }

    [Authorize]
    [ServiceFilter(typeof(AuthorizeOwnerFilter))]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateProductDto productDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var updatedProduct = await _mediator.Send(new UpdateProductCommand(id, productDto));

        return Ok(updatedProduct);
    }

    [Authorize]
    [ServiceFilter(typeof(AuthorizeOwnerFilter))]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteById([FromRoute] int id)
    {
        await _mediator.Send(new DeleteProductCommand(id));

        return NoContent();
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("soft-delete/{id:int}")]
    public async Task<IActionResult> SoftDeleteByOwnerId([FromRoute] int id)
    {
        await _mediator.Send(new SoftDeleteProductCommand(id));

        return NoContent();
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("recover/{id:int}")]
    public async Task<IActionResult> RecoverDeletedByOwnerId([FromRoute] int id)
    {
        await _mediator.Send(new RecoverProductsByOwnerIdCommand(id));

        return NoContent();
    }
}
