using AutoMapper;
using InnoShop.UsersManagementService.Application.Commands;
using InnoShop.UsersManagementService.Application.Dtos.Responses;
using InnoShop.UsersManagementService.Domain.Interfaces.Repositories;
using InnoShop.UsersManagementService.Domain.Exceptions;
using MediatR;
using InnoShop.UsersManagementService.Domain.Interfaces;

namespace InnoShop.UsersManagementService.Application.Handlers;

public class LoginHandler(IUsersRepository _usersRepository, IMapper _mapper,
                          IPasswordHasher _passwordHasher, IJwtTokenGenerator _jwtTokenGenerator
                         ) : IRequestHandler<LoginCommand, LoginResponseDto>
{
    public async Task<LoginResponseDto> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _usersRepository.GetByUsernameAsync(request.LoginDto.Username);

        if (user is null || _passwordHasher.VerifyPassword(user, request.LoginDto.Password) == false)
        {
            throw new LoginFailureException();
        }

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new LoginResponseDto { AccessToken = token };
    }
}
