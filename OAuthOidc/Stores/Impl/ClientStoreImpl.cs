using Microsoft.EntityFrameworkCore;
using OAuthOidc.Data.Clients;
using OAuthOidc.Data.DbContexts;

namespace OAuthOidc.Stores.Impl
{
    public class ClientStoreImpl : IClientStore
    {
        private readonly ConfigurationDbContext _configurationDbContext;

        public ClientStoreImpl(ConfigurationDbContext configurationDbContext)
        {
            _configurationDbContext = configurationDbContext;
        }

        public async Task<Client> SingleByIdAsync(string clientId)
        {
            return await _configurationDbContext.Clients.AsNoTrackingWithIdentityResolution().Where(p => p.ClientId == clientId)
                .Include(p => p.ClientSecrets)
                .Include(p => p.RedirectUris)
                .Include(p => p.ApiScopes).ThenInclude(p => p.ApiScope)
                .Include(p => p.IdentityScopes).ThenInclude(p => p.IdentityResource)
                .SingleOrDefaultAsync();
        }
    }
}
