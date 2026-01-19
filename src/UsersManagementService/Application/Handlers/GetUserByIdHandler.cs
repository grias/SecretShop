using AutoMapper;
using InnoShop.UsersManagementService.Application.Dtos.Responses;
using InnoShop.UsersManagementService.Application.Queries;
using InnoShop.UsersManagementService.Domain.Interfaces.Repositories;
using InnoShop.UsersManagementService.Domain.Exceptions;
using MediatR;

namespace InnoShop.UsersManagementService.Application.Handlers;

public class GetUserByIdHandler(IUsersRepository _usersRepository, IMapper _mapper) : IRequestHandler<GetUserByIdQuery, UserDto>
{
    public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _usersRepository.GetByIdAsync(request.Id);

        if (user is null)
        {
            throw new UserNotFoundException(request.Id);
        }

        return _mapper.Map<UserDto>(user);
    }
}
