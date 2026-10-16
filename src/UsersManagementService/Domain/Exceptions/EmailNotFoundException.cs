using System.Net;

namespace InnoShop.UsersManagementService.Domain.Exceptions;

public class EmailNotFoundException : BaseException
{
    public EmailNotFoundException(string email)
        : base($"User with email {email} not found",HttpStatusCode.NotFound)
    {
    }
}
