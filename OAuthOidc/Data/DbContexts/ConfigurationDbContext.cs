using Microsoft.EntityFrameworkCore;
using OAuthOidc.Data.ApiResources;
using OAuthOidc.Data.Clients;
using OAuthOidc.Data.IdentityResources;
using System.Diagnostics.CodeAnalysis;

namespace OAuthOidc.Data.DbContexts
{
    public class ConfigurationDbContext : DbContext
    {
        public ConfigurationDbContext([NotNull] DbContextOptions<ConfigurationDbContext> options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<ApiScope> ApiScopes { get; set; }
        public DbSet<ApiResource> ApiResources { get; set; }
        public DbSet<IdentityResource> IdentityResources { get; set; }
    }
}
