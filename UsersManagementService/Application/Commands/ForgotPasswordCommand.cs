using InnoShop.UsersManagementService.Application.Dtos.Requests;
using MediatR;

namespace InnoShop.UsersManagementService.Application.Commands;

public record ForgotPasswordCommand(ForgotPasswordRequestDto Dto) : IRequest;
