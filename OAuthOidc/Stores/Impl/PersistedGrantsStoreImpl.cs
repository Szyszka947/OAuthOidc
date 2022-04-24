using OAuthOidc.Data.DbContexts;
using OAuthOidc.Data.PersistedGrants;

namespace OAuthOidc.Stores.Impl
{
    public class PersistedGrantsStoreImpl : IPersistedGrantsStore
    {
        private readonly PersistedGrantsDbContext _persistedGrantsDbContext;

        public PersistedGrantsStoreImpl(PersistedGrantsDbContext persistedGrantsDbContext)
        {
            _persistedGrantsDbContext = persistedGrantsDbContext;
        }

        public async Task<PersistedGrant> FindByIdAsync(Guid id)
        {
            return await _persistedGrantsDbContext.PersistedGrants.FindAsync(id);
        }
    }
}
