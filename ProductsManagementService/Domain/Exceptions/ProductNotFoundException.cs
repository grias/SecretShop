using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace InnoShop.ProductsManagementService.Domain.Exceptions;

public class ProductNotFoundException : BaseException
{
    public ProductNotFoundException(int id) 
        : base($"Product with id {id} not found", HttpStatusCode.NotFound)
    {
    }
}
