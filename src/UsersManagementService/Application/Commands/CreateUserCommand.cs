using InnoShop.UsersManagementService.Application.Dtos.Responses;
using InnoShop.UsersManagementService.Application.Dtos.Requests;
using MediatR;

namespace InnoShop.UsersManagementService.Application.Commands;

public record CreateUserCommand(CreateUserDto UserDto) : IRequest<UserDto>;
