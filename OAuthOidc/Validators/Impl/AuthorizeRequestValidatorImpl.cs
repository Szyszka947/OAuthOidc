using OAuthOidc.Data.Clients;
using OAuthOidc.Models;
using OAuthOidc.Models.Errors;

namespace OAuthOidc.Validators.Impl
{
    public class AuthorizeRequestValidatorImpl : IAuthorizeRequestValidator
    {
        /// <summary>
        /// Authorization Code grant validator.
        /// </summary>
        /// <param name="request">AuthorizationRequest</param>
        /// <param name="client">The client.</param>
        /// <returns>Result base</returns>
        public ResultBase Validate(AuthorizationRequest authorizationRequest, Client client)
        {
            if (client is null || authorizationRequest.CodeChallenge is null
                || authorizationRequest.RedirectUri is null || authorizationRequest.State is null
                || !client.RedirectUris.Any(p => p.RedirectUri == authorizationRequest.RedirectUri))
                return new InvalidRequest();

            if (authorizationRequest.Scope != null)
            {
                var requestedScopes = authorizationRequest.Scope.Split(" ");

                foreach (var item in requestedScopes)
                {
                    if (client.ApiScopes.Any(p => p.ApiScope.Name == item)
                        || client.IdentityScopes.Any(p => p.IdentityResource.Name == item))
                        continue;
                    else return new InvalidScope();
                }
            }

            if (!authorizationRequest.ResponseType.IsResponseTypeValid())
                return new UnsupportedResponseType();

            if (client.GrantType != GrantTypes.AuthorizationCode)
                return new UnauthorizedClient();

            return null;
        }
    }
}
