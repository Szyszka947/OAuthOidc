using Microsoft.AspNetCore.Mvc;
using OAuthOidc.Models;

namespace OAuthOidc.Handlers.TokenEndpoint
{
    public interface IInvalidGrantHandler
    {
        Task<IActionResult> HandleAsync(TokenRequest tokenRequest, string origin);
    }
}
