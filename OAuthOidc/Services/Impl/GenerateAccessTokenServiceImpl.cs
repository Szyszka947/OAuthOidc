using Microsoft.IdentityModel.Tokens;
using OAuthOidc.Data.Clients;
using OAuthOidc.Models;
using OAuthOidc.Stores;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;

namespace OAuthOidc.Services.Impl
{
    public class GenerateAccessTokenServiceImpl : IGenerateAccessTokenService
    {
        private readonly IApiResourcesStore _apiResourcesStore;

        public GenerateAccessTokenServiceImpl(IApiResourcesStore apiResourcesStore)
        {
            _apiResourcesStore = apiResourcesStore;
        }

        public async Task<TokenResponse> GenerateAsync(TokenRequest tokenRequest, Client client, string issuer, bool withIdentityScopes)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var rsa = RSA.Create();
            var privateKeyPem = await File.ReadAllTextAsync("rsa.private");

            rsa.ImportFromPem(privateKeyPem);

            var signingCredentials = new SigningCredentials(new RsaSecurityKey(rsa), SecurityAlgorithms.RsaSha256)
            {
                CryptoProviderFactory = new CryptoProviderFactory { CacheSignatureProviders = false }
            };

            var scopes = tokenRequest.Scope == null ? client.ApiScopes.Select(p => p.ApiScope.Name).ToList() : tokenRequest.Scope.Split(" ").ToList();

            if (withIdentityScopes)
                scopes.AddRange(client.IdentityScopes.Select(p => p.IdentityResource.Name).ToList());

            var audiences = (await _apiResourcesStore.FindByScopesNameAsync(scopes.ToList())).Select(p => p.Name);

            object audience = audiences.Count() > 1 ? audiences : audiences.Distinct();

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                NotBefore = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddSeconds(client.AccessTokenLifetime),
                Issuer = issuer,
                Claims = new Dictionary<string, object>
                {
                    { "client_id", client.ClientId },
                    { JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString().ToUpper() },
                    { "scope", scopes },
                    { JwtRegisteredClaimNames.Aud, audience }
                },
                IssuedAt = DateTime.UtcNow,
                SigningCredentials = signingCredentials
            };

            var securityToken = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);

            var accessToken = tokenHandler.WriteToken(securityToken);

            return new TokenResponse
            {
                AccessToken = accessToken,
                ExpiresIn = client.AccessTokenLifetime,
                Scope = string.Join(" ", scopes),
                TokenType = TokenTypes.Bearer
            };
        }
    }
}
