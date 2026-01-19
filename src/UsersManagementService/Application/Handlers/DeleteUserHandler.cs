using InnoShop.UsersManagementService.Application.Commands;
using InnoShop.UsersManagementService.Domain.Exceptions;
using InnoShop.UsersManagementService.Domain.Interfaces;
using InnoShop.UsersManagementService.Domain.Interfaces.Repositories;
using MediatR;

namespace InnoShop.UsersManagementService.Application.Handlers;

public class DeleteUserHandler(IUsersRepository _usersRepository, IProductsDeletionManager _deletionManager, 
                               IJwtTokenGenerator _tokenGenerator) : IRequestHandler<DeleteUserCommand>
{
    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _usersRepository.GetByIdAsync(request.Id);

        if (user is null)
        {
            throw new UserNotFoundException(request.Id);
        }

        await DeleteProductsByOwnerId(request.Id);

        await _usersRepository.DeleteAsync(request.Id);
    }

    private async Task DeleteProductsByOwnerId(int id)
    {
        var admin = await _usersRepository.GetByUsernameAsync("admin");
        var adminToken = _tokenGenerator.GenerateToken(admin!);

        await _deletionManager.SoftDeleteByOwnerIdAsync(id, adminToken);
    }
}
