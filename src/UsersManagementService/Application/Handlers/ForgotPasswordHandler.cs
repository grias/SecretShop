using InnoShop.UsersManagementService.Application.Commands;
using InnoShop.UsersManagementService.Domain.Exceptions;
using InnoShop.UsersManagementService.Domain.Interfaces;
using InnoShop.UsersManagementService.Domain.Interfaces.Repositories;
using MediatR;

namespace InnoShop.UsersManagementService.Application.Handlers;

public class ForgotPasswordHandler(IUsersRepository _usersRepository, IRecoveryTokenGenerator _recoveryTokenGenerator, IPasswordRecoveryEmailSender _emailSender) : IRequestHandler<ForgotPasswordCommand>
{
    public async Task Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await _usersRepository.GetByEmailAsync(request.Dto.Email);
        if (user is null)
        {
            throw new EmailNotFoundException(request.Dto.Email);
        }

        var token = _recoveryTokenGenerator.GenerateToken(user);

        _emailSender.SendEmail(token, request.Dto.Email);
    }
}
