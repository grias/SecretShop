using InnoShop.ProductsManagementService.Application.Commands;
using InnoShop.ProductsManagementService.Application.Dtos;
using InnoShop.ProductsManagementService.Application.Dtos.Requests;
using InnoShop.ProductsManagementService.Application.Queries;
using InnoShop.ProductsManagementService.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductDto productDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdProduct = await _mediator.Send(new CreateProductCommand(productDto));

        return Ok(createdProduct);
    }

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

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteById([FromRoute] int id)
    {
        await _mediator.Send(new DeleteProductCommand(id));

        return NoContent();
    }
}
