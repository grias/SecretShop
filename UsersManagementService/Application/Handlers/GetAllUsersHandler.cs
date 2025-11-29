using AutoMapper;
using InnoShop.UsersManagementService.Application.Dtos.Responses;
using InnoShop.UsersManagementService.Application.Queries;
using InnoShop.UsersManagementService.Domain.Interfaces.Repositories;
using MediatR;

namespace InnoShop.UsersManagementService.Application.Handlers;

public class GetAllUsersHandler(IUsersRepository _usersRepository, IMapper _mapper) : IRequestHandler<GetAllUsersQuery, List<UserDto>>
{
    public async Task<List<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _usersRepository.GetAllAsync(request.QueryObject);
        return _mapper.Map<List<UserDto>>(users);
    }
}
