using Microsoft.EntityFrameworkCore;
using OAuthOidc.Data.ApiResources;
using OAuthOidc.Data.DbContexts;

namespace OAuthOidc.Stores.Impl
{
    public class ApiResourcesStoreImpl : IApiResourcesStore
    {
        private readonly ConfigurationDbContext _configurationDbContext;

        public ApiResourcesStoreImpl(ConfigurationDbContext configurationDbContext)
        {
            _configurationDbContext = configurationDbContext;
        }

        public async Task<List<ApiResource>> FindByScopesNameAsync(List<string> scopes)
        {
            return await _configurationDbContext.ApiResources.AsNoTrackingWithIdentityResolution().
                Where(p => p.Scopes.Any(x => scopes.Any(y => y == x.ApiScope.Name))).Select(p => p).ToListAsync();
        }

        public async Task<List<ApiResourceScope>> GetApiResourceScopesAsync(string apiResourceName)
        {
            return await _configurationDbContext.ApiResources.AsNoTrackingWithIdentityResolution()
                .Where(p => p.Name == apiResourceName).Select(p => p.Scopes).SelectMany(p => p).ToListAsync();
        }
    }
}
