using System.ComponentModel.DataAnnotations;

namespace InnoShop.UsersManagementService.Domain.Queries;

public class UserQueryObject
{
    private static readonly int _firstPage = 1;
    private static readonly int _defaultPageSize = 5;

    [Range(1, int.MaxValue)]
    public int PageNumber { get; set; } = _firstPage;

    [Range(1, int.MaxValue)]
    public int PageSize { get; set; } = _defaultPageSize;

    public string? Username { get; set; }
}
