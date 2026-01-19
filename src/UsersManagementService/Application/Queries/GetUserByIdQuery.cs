using InnoShop.UsersManagementService.Application.Dtos.Responses;
using MediatR;

namespace InnoShop.UsersManagementService.Application.Queries;

public record GetUserByIdQuery(int Id) : IRequest<UserDto>;
