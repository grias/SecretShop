using InnoShop.UsersManagementService.Application.Dtos.Responses;
using MediatR;

namespace InnoShop.UsersManagementService.Application.Commands;

public record RecoverUserCommand(int Id) : IRequest<UserDto>;