using OAuthOidc.Data.Clients;
using OAuthOidc.Models;
using OAuthOidc.Models.Errors;

namespace OAuthOidc.Validators
{
    public interface IGrantValidator
    {
        Task<ResultBase> Validate(TokenRequest request, Client client);
    }
}
