using MediatR;

namespace InnoShop.ProductsManagementService.Application.Commands;

public record SoftDeleteProductCommand(int OwnerId) : IRequest;
