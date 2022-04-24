using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using NSec.Cryptography;
using OAuthOidc.Data.Clients;
using OAuthOidc.Data.PersistedGrants;
using OAuthOidc.Models;
using OAuthOidc.Models.Errors;
using OAuthOidc.Stores;
using System.Text;

namespace OAuthOidc.Validators.Impl
{
    public class AuthorizationCodeGrantValidatorImpl : IGrantValidator
    {
        private readonly IPersistedGrantsStore _persistedGrantsStore;

        public AuthorizationCodeGrantValidatorImpl(IPersistedGrantsStore persistedGrantsStore)
        {
            _persistedGrantsStore = persistedGrantsStore;
        }

        public async Task<ResultBase> Validate(TokenRequest tokenRequest, Client client)
        {
            if (client is null || tokenRequest.RedirectUri is null || tokenRequest.Code is null || tokenRequest.CodeVerifier is null)
                return new InvalidRequest();

            if (tokenRequest.ClientSecret is null ||
                client.ClientSecrets.FirstOrDefault(p => HashAlgorithm.Sha256.Verify(Encoding.UTF8.GetBytes(tokenRequest.ClientSecret), p.Value)) == default)
                return new InvalidClient();

            if (!tokenRequest.GrantType.IsGrantTypeValid()) return new UnsupportedGrantType();

            if (tokenRequest.GrantType != client.GrantType) return new UnauthorizedClient();

            if (tokenRequest.Scope != null)
            {
                var requestedScopes = tokenRequest.Scope.Split(" ");

                foreach (var item in requestedScopes)
                {
                    if (client.ApiScopes.Any(p => p.ApiScope.Name == item)
                        || client.IdentityScopes.Any(p => p.IdentityResource.Name == item))
                        continue;
                    else return new InvalidScope();
                }
            }

            PersistedGrant persistedGrant;
            try
            {
                persistedGrant = await _persistedGrantsStore.FindByIdAsync(Guid.Parse(tokenRequest.Code));
            }
            catch
            {
                return new InvalidAuthorizationCode();
            }

            var authCode = JsonConvert.DeserializeObject<AuthorizationCode>(persistedGrant.Data);

            if (persistedGrant.ClientId != tokenRequest.ClientId || persistedGrant.Expiration <= DateTime.UtcNow
                || persistedGrant.Type != PersistedGrantTypes.AuthorizationCode)
                return new InvalidAuthorizationCode();

            switch (authCode.CodeChallengeMethod)
            {
                case CodeChallengeMethods.S256:
                    if (Base64UrlEncoder.Encode(HashAlgorithm.Sha256.Hash(Encoding.UTF8.GetBytes(tokenRequest.CodeVerifier))) != authCode.CodeChallenge)
                        return new InvalidCodeVerifier();
                    break;
                case CodeChallengeMethods.Plain:
                    if (tokenRequest.CodeVerifier != authCode.CodeChallenge)
                        return new InvalidCodeVerifier();
                    break;
                default:
                    return new InvalidCodeChallengeMethod();
            }

            return null;
        }
    }
}
