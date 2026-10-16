using InnoShop.UsersManagementService.Application.Dtos.Requests;
using MediatR;

namespace InnoShop.UsersManagementService.Application.Commands;

public record ResetPasswordCommand(ResetPasswordRequestDto Dto) : IRequest;