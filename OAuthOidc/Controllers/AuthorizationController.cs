using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using OAuthOidc.Handlers.AuthorizationEndpoint;
using OAuthOidc.Models;
using OAuthOidc.Services;

namespace OAuthOidc.Controllers
{
    [Route("api/openid/v2.0")]
    public class AuthorizationController : Controller
    {
        private readonly IAuthorizeHandler _authorizeHandler;
        private readonly IGenerateAuthorizationCodeService _generateAuthorizationCodeService;

        public AuthorizationController(IAuthorizeHandler authorizeHandler, IGenerateAuthorizationCodeService generateAuthorizationCodeService)
        {
            _authorizeHandler = authorizeHandler;
            _generateAuthorizationCodeService = generateAuthorizationCodeService;
        }

        [HttpGet("authorize")]
        public async Task<IActionResult> Authorize([FromQuery] AuthorizationRequest authorizationRequest)
        {
            var (result, code) = await _authorizeHandler.HandleAsync(authorizationRequest, HttpContext.User.Identity.Name);

            if (result == null)
                if (HttpContext.User.Identity.IsAuthenticated)
                    return Redirect(authorizationRequest.RedirectUri + $"?code={code}&state={authorizationRequest.State}");
                else
                    return Challenge(CookieAuthenticationDefaults.AuthenticationScheme);

            return result;
        }
    }
}
