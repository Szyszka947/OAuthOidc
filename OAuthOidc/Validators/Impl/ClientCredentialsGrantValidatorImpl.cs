using NSec.Cryptography;
using OAuthOidc.Data.Clients;
using OAuthOidc.Models;
using OAuthOidc.Models.Errors;
using System.Text;

namespace OAuthOidc.Validators.Impl
{
    public class ClientCredentialsGrantValidatorImpl : IGrantValidator
    {
        /// <summary>
        /// Client Credentials grant validator.
        /// </summary>
        /// <param name="tokenRequest">Token request</param>
        /// <param name="client">The client</param>
        /// <returns>Result base</returns>
        public async Task<ResultBase> Validate(TokenRequest tokenRequest, Client client)
        {
            if (client is null) return new InvalidRequest();

            if (tokenRequest.ClientSecret is null
                || client.ClientSecrets.FirstOrDefault(p => HashAlgorithm.Sha256.Verify(Encoding.UTF8.GetBytes(tokenRequest.ClientSecret), p.Value)) == default)
                return new InvalidClient();

            if (!tokenRequest.GrantType.IsGrantTypeValid()) return new UnsupportedGrantType();

            if (tokenRequest.GrantType != client.GrantType) return new UnauthorizedClient();

            if (tokenRequest.Scope != null && tokenRequest.Scope.Split(" ").Any(p => client.ApiScopes.Any(x => x.ApiScope.Name == p) == false))
                return new InvalidScope();

            return null;
        }
    }
}
