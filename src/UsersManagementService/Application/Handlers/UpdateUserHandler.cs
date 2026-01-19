using AutoMapper;
using InnoShop.UsersManagementService.Application.Commands;
using InnoShop.UsersManagementService.Application.Dtos.Responses;
using InnoShop.UsersManagementService.Domain.Exceptions;
using InnoShop.UsersManagementService.Domain.Interfaces;
using InnoShop.UsersManagementService.Domain.Interfaces.Repositories;
using MediatR;

namespace InnoShop.UsersManagementService.Application.Handlers;

public class UpdateUserHandler(IUsersRepository _usersRepository, IMapper _mapper) : IRequestHandler<UpdateUserCommand, UserDto>
{
    public async Task<UserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var existingUser = await _usersRepository.GetByIdAsync(request.Id);

        if (existingUser is null)
        {
            throw new UserNotFoundException(request.Id);
        }

        var userToUpdate = _mapper.Map(request.UserDto, existingUser);
        var updatedUser = await _usersRepository.UpdateAsync(userToUpdate);
        return _mapper.Map<UserDto>(updatedUser);
    }
}
