using InnoShop.UsersManagementService.Domain.Interfaces;
using System.Net.Http.Headers;

namespace InnoShop.UsersManagementService.Infrastructure.DeletionManagers;

public class ProductDeletionManager(HttpClient _httpClient) : IProductsDeletionManager
{
    public async Task RecoverByOwnerIdAsync(int id, string accessToken)
    {
        var uri = $"api/Products/recover/{id}";
        await SendHttpRequest(HttpMethod.Post, uri, accessToken);
    }

    public async Task SoftDeleteByOwnerIdAsync(int id, string accessToken)
    {
        var uri = $"api/Products/soft-delete/{id}";
        await SendHttpRequest(HttpMethod.Delete, uri, accessToken);
    }

    private async Task SendHttpRequest(HttpMethod method, string uri, string accessToken)
    {
        var request = new HttpRequestMessage(method, uri);
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

        var response = await _httpClient.SendAsync(request);

        response.EnsureSuccessStatusCode();
    }
}
