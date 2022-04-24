using OAuthOidc.Data.Clients;
using OAuthOidc.Models;

namespace OAuthOidc.Services
{
    public interface IGenerateAccessTokenService
    {
        Task<TokenResponse> GenerateAsync(TokenRequest tokenRequest, Client client, string issuer, bool withIdentityScopes);
    }
}
