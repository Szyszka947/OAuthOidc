using OAuthOidc.Data.ApiResources;

namespace OAuthOidc.Stores
{
    public interface IApiResourcesStore
    {
        Task<List<ApiResource>> FindByScopesNameAsync(List<string> scopes);
        Task<List<ApiResourceScope>> GetApiResourceScopesAsync(string apiResourceName);
    }
}
