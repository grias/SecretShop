using InnoShop.UsersManagementService.Application.Commands;
using InnoShop.UsersManagementService.Domain.Exceptions;
using InnoShop.UsersManagementService.Domain.Interfaces;
using InnoShop.UsersManagementService.Domain.Interfaces.Repositories;
using MediatR;

namespace InnoShop.UsersManagementService.Application.Handlers;

public class ForgotPasswordHandler(IUsersRepository _usersRepository) : IRequestHandler<ForgotPasswordCommand>
{
    public async Task Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await _usersRepository.GetByEmailAsync(request.Dto.Email);
        if (user is null)
        {
            throw new UserNotFoundException();
        }

        var token = _jwtTokenGenerator.GenerateToken(user);

        var result = _emailSender.SendEmail(token, request.Dto.Email);

        return result;
    }
}
