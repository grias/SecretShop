using InnoShop.UsersManagementService.Application.Commands;
using InnoShop.UsersManagementService.Domain.Exceptions;
using InnoShop.UsersManagementService.Domain.Interfaces;
using InnoShop.UsersManagementService.Domain.Interfaces.Repositories;
using MediatR;


namespace InnoShop.UsersManagementService.Application.Handlers;

internal class ResetPasswordHandler(IUsersRepository _usersRepository, IRecoveryTokenValidator _recoveryTokenValidator,
                                    IPasswordHasher _passwordHasher) : IRequestHandler<ResetPasswordCommand>
{
    public async Task Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
    {
        var token = request.Dto.Token;

        var userId = _recoveryTokenValidator.ReadUserIdWithoutValidation(token);

        if (userId is null)
        {
            throw new BadRequestException("Incorrect token format");
        }

        var user = await _usersRepository.GetByIdAsync(userId.Value);

        if (user is null)
        {
            throw new UserNotFoundException(userId.Value);
        }

        var principal = _recoveryTokenValidator.ValidateToken(token, user);

        if (principal is null)
        {
            throw new BadRequestException("Incorrect token format");
        }

        var newPasswordHash = _passwordHasher.HashPassword(user, request.Dto.NewPassword);

        if (newPasswordHash == user.PasswordHash)
        {
            throw new InvalidPasswordException("New password must not match current password");
        }

        user.PasswordHash = newPasswordHash;

        await _usersRepository.UpdateAsync(user);
    }
}
