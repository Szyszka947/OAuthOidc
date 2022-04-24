using Microsoft.EntityFrameworkCore;
using OAuthOidc.Data.PersistedGrants;

namespace OAuthOidc.Data.DbContexts
{
    public class PersistedGrantsDbContext : DbContext
    {
        public PersistedGrantsDbContext(DbContextOptions<PersistedGrantsDbContext> options) : base(options)
        {
        }

        public DbSet<PersistedGrant> PersistedGrants { get; set; }
    }
}
