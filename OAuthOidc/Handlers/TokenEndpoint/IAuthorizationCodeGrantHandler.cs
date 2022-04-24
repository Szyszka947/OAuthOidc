using Microsoft.AspNetCore.Mvc;
using OAuthOidc.Models;

namespace OAuthOidc.Handlers.TokenEndpoint
{
    public interface IAuthorizationCodeGrantHandler
    {
        Task<IActionResult> HandleAsync(TokenRequest tokenRequest, string origin);
    }
}
