using AutoMapper;
using InnoShop.UsersManagementService.Application.Commands;
using InnoShop.UsersManagementService.Application.Dtos.Responses;
using InnoShop.UsersManagementService.Domain.Exceptions;
using InnoShop.UsersManagementService.Domain.Interfaces;
using InnoShop.UsersManagementService.Domain.Interfaces.Repositories;
using MediatR;

namespace InnoShop.UsersManagementService.Application.Handlers;

public class RecoverUserHandler(IUsersRepository _usersRepository, IProductsDeletionManager _deletionManager,
                               IJwtTokenGenerator _tokenGenerator, IMapper _mapper) : IRequestHandler<RecoverUserCommand, UserDto>
{
    public async Task<UserDto> Handle(RecoverUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _usersRepository.GetByIdAsync(request.Id);

        if (user is null)
        {
            throw new UserNotFoundException(request.Id);
        }

        await RecoverProductsByOwnerId(request.Id);

        var recoveredUser = await _usersRepository.RecoverAsync(request.Id);

        return _mapper.Map<UserDto>(recoveredUser);
    }

    private async Task RecoverProductsByOwnerId(int id)
    {
        var admin = await _usersRepository.GetByUsernameAsync("admin");
        var adminToken = _tokenGenerator.GenerateToken(admin!);

        await _deletionManager.RecoverByOwnerIdAsync(id, adminToken);
    }
}
