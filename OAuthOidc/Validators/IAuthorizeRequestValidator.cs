using OAuthOidc.Data.Clients;
using OAuthOidc.Models;
using OAuthOidc.Models.Errors;

namespace OAuthOidc.Validators
{
    public interface IAuthorizeRequestValidator
    {
        ResultBase Validate(AuthorizationRequest authorizationRequest, Client client);
    }
}
