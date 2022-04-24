using OAuthOidc.Data.PersistedGrants;

namespace OAuthOidc.Stores
{
    public interface IPersistedGrantsStore
    {
        Task<PersistedGrant> FindByIdAsync(Guid id);
    }
}
