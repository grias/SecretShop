using InnoShop.UsersManagementService.Domain.Queries;
using InnoShop.UsersManagementService.Application.Dtos.Responses;
using MediatR;

namespace InnoShop.UsersManagementService.Application.Queries;

public record GetAllUsersQuery(UserQueryObject QueryObject) : IRequest<List<UserDto>>;
