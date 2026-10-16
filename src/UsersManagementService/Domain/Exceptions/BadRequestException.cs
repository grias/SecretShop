using System.Net;

namespace InnoShop.UsersManagementService.Domain.Exceptions;

public class BadRequestException(string message) : BaseException(message, HttpStatusCode.BadRequest)
{
}
