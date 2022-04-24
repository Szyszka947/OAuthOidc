using Microsoft.AspNetCore.Mvc;
using OAuthOidc.Models;

namespace OAuthOidc.Handlers.TokenEndpoint
{
    public interface IClientCredentialsGrantHandler
    {
        Task<IActionResult> HandleAsync(TokenRequest tokenRequest, string origin);
    }
}
