using InnoShop.UsersManagementService.Application.Dtos.Requests;
using InnoShop.UsersManagementService.Application.Dtos.Responses;
using MediatR;

namespace InnoShop.UsersManagementService.Application.Commands;

public record LoginCommand(LoginRequestDto LoginDto) :IRequest<LoginResponseDto>;
