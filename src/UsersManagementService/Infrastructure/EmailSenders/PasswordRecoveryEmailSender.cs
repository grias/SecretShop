using InnoShop.UsersManagementService.Domain.Interfaces;

namespace InnoShop.UsersManagementService.Infrastructure.EmailSenders;

public class PasswordRecoveryEmailSender : IPasswordRecoveryEmailSender
{
    public void SendEmail(string token, string email)
    {
        Console.WriteLine($"Recovery token sent to email: {email}!\n{token}");
    }
}
