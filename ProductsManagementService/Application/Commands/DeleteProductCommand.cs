using MediatR;

namespace InnoShop.ProductsManagementService.Application.Commands;

public record DeleteProductCommand(int Id) : IRequest;
