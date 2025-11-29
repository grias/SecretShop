using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace InnoShop.UsersManagementService.Domain.Exceptions;

public class LoginFailureException : BaseException
{
    public LoginFailureException() 
        : base("Incorrect username or password", HttpStatusCode.Unauthorized)
    {
    }
}
