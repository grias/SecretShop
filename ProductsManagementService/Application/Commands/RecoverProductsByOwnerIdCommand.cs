using MediatR;

namespace InnoShop.ProductsManagementService.Application.Commands;

public record RecoverProductsByOwnerIdCommand(int OwnerId) : IRequest;
