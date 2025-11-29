namespace InnoShop.UsersManagementService.Domain.Interfaces;

public interface IPasswordRecoveryEmailSender
{
    bool SendEmail(string token, string email);
}
