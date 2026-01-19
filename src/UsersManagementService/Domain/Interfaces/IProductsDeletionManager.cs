namespace InnoShop.UsersManagementService.Domain.Interfaces;

public interface IProductsDeletionManager
{
    Task SoftDeleteByOwnerIdAsync(int id, string accessToken);
    Task RecoverByOwnerIdAsync(int id, string accessToken);
}
