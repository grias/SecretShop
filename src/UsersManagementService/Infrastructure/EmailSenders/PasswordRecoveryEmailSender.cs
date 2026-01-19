using InnoShop.UsersManagementService.Domain.Interfaces;

namespace InnoShop.UsersManagementService.Infrastructure.EmailSenders;

public class PasswordRecoveryEmailSender : IPasswordRecoveryEmailSender
{
    public bool SendEmail(string token, string email)
    {
        throw new NotImplementedException();
    }
}
