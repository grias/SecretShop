using AutoMapper;
using InnoShop.UsersManagementService.Application.Commands;
using InnoShop.UsersManagementService.Application.Dtos.Responses;
using InnoShop.UsersManagementService.Domain.Interfaces.Repositories;
using InnoShop.UsersManagementService.Domain.Entities;
using MediatR;

namespace InnoShop.UsersManagementService.Application.Handlers;

public class CreateUserHandler(IUsersRepository _usersRepository, IMapper _mapper) : IRequestHandler<CreateUserCommand, UserDto>
{
    public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var userToCreate = _mapper.Map<User>(request.UserDto);
        var createdUser = await _usersRepository.CreateAsync(userToCreate);
        return _mapper.Map<UserDto>(createdUser);
    }
}
