using System.Net;

namespace InnoShop.UsersManagementService.Domain.Exceptions;

public class InvalidPasswordException(string message) : BaseException(message, HttpStatusCode.BadRequest)
{
}
