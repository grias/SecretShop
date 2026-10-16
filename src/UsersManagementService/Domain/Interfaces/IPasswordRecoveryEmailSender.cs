namespace InnoShop.UsersManagementService.Domain.Interfaces;

public interface IPasswordRecoveryEmailSender
{
    void SendEmail(string token, string email);
}
