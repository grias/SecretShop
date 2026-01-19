using System.Net;

namespace InnoShop.UsersManagementService.Domain.Exceptions;

public class UserNotFoundException : BaseException
{
    public UserNotFoundException(int id) 
        : base($"User with id {id} not found", HttpStatusCode.NotFound)
    {
    }
}
