using InnoShop.UsersManagementService.Application.Commands;
using MediatR;

namespace InnoShop.UsersManagementService.Application.Handlers;

public class ForgotPasswordHandler : IRequestHandler<ForgotPasswordCommand>
{
    public Task Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
    {

        throw new NotImplementedException();
    }
}
