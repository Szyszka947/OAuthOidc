using Microsoft.AspNetCore.Mvc;
using OAuthOidc.Models;

namespace OAuthOidc.Handlers.AuthorizationEndpoint
{
    public interface IAuthorizeHandler
    {
        Task<(IActionResult result, string code)> HandleAsync(AuthorizationRequest authorizationRequest, string email);
    }
}
