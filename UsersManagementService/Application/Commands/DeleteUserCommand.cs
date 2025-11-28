using MediatR;

namespace InnoShop.UsersManagementService.Application.Commands;

public record DeleteUserCommand(int Id) : IRequest;