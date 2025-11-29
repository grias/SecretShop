using AutoMapper;
using InnoShop.UsersManagementService.Application.Commands;
using InnoShop.UsersManagementService.Application.Dtos.Responses;
using InnoShop.UsersManagementService.Domain.Entities;
using InnoShop.UsersManagementService.Domain.Enumerators;
using InnoShop.UsersManagementService.Domain.Interfaces;
using InnoShop.UsersManagementService.Domain.Interfaces.Repositories;
using MediatR;

namespace InnoShop.UsersManagementService.Application.Handlers;

public class RegisterHandler(IUsersRepository _usersRepository, IMapper _mapper,
                             IPasswordHasher _passwordHasher, IJwtTokenGenerator _jwtTokenGenerator
                            ) : IRequestHandler<RegisterCommand, RegisterResponseDto>
{
    public async Task<RegisterResponseDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var userToCreate = _mapper.Map<User>(request.RegisterDto);

        userToCreate.PasswordHash = _passwordHasher.HashPassword(userToCreate, request.RegisterDto.Password);
        userToCreate.Role = UserRoles.User;

        var createdUser = await _usersRepository.CreateAsync(userToCreate);

        return new RegisterResponseDto { AccessToken = _jwtTokenGenerator.GenerateToken(createdUser) };
    }
}
