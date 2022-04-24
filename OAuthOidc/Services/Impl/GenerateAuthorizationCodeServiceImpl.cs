using Newtonsoft.Json;
using OAuthOidc.Data.DbContexts;
using OAuthOidc.Data.PersistedGrants;
using OAuthOidc.Data.Users;
using OAuthOidc.Models;
using OAuthOidc.Stores;

namespace OAuthOidc.Services.Impl
{
    public class GenerateAuthorizationCodeServiceImpl : IGenerateAuthorizationCodeService
    {
        private readonly PersistedGrantsDbContext _persistedGrantsDbContext;
        private readonly IClientStore _clientStore;

        public GenerateAuthorizationCodeServiceImpl(PersistedGrantsDbContext persistedGrantsDbContext, IClientStore clientStore)
        {
            _persistedGrantsDbContext = persistedGrantsDbContext;
            _clientStore = clientStore;
        }

        public async Task<string> GenerateAsync(string clientId, string codeChallenge, string codeChallengeMethod, List<string> requestedScopes, string redirectUri, int userId)
        {
            var client = await _clientStore.SingleByIdAsync(clientId);

            var dateTimeNow = DateTime.UtcNow.ToString();
            var authorizationCode = new AuthorizationCode
            {
                Claims = new List<UserClaim>
                {
                    new UserClaim { Type = "sub", Value = userId.ToString() },
                    new UserClaim { Type = "auth_time", Value = dateTimeNow },
                },
                ClientId = clientId,
                CodeChallenge = codeChallenge,
                CodeChallengeMethod = codeChallengeMethod,
                CreatedAt = dateTimeNow,
                RedirectUri = redirectUri,
                Scopes = requestedScopes
            };

            var persistedGrant = new PersistedGrant
            {
                ClientId = clientId,
                Expiration = DateTime.UtcNow.AddSeconds(client.AuthorizationCodeLifetime),
                Type = PersistedGrantTypes.AuthorizationCode,
                Data = JsonConvert.SerializeObject(authorizationCode)
            };

            await _persistedGrantsDbContext.PersistedGrants.AddAsync(persistedGrant);
            await _persistedGrantsDbContext.SaveChangesAsync();

            return persistedGrant.Id.ToString();
        }
    }
}
