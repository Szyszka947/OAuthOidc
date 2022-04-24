using Microsoft.AspNetCore.Mvc;
using OAuthOidc.Data.DbContexts;
using OAuthOidc.Handlers.TokenEndpoint;
using OAuthOidc.Models;

namespace OAuthOidc.Controllers
{
    [Route("api/oauth/v2.1")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IClientCredentialsGrantHandler _clientCredentialsGrantHandler;
        private readonly IAuthorizationCodeGrantHandler _authorizationCodeGrantHandler;
        private readonly IInvalidGrantHandler _invalidGrantHandler;
        private readonly ConfigurationDbContext _configurationDbContext;

        public TokenController(IClientCredentialsGrantHandler clientCredentialsGrantHandler, IInvalidGrantHandler invalidGrantHandler,
            ConfigurationDbContext configurationDbContext, IAuthorizationCodeGrantHandler authorizationCodeGrantHandler)
        {
            _clientCredentialsGrantHandler = clientCredentialsGrantHandler;
            _invalidGrantHandler = invalidGrantHandler;
            _configurationDbContext = configurationDbContext;
            _authorizationCodeGrantHandler = authorizationCodeGrantHandler;
        }

        //POST api/oauth/v2.1/token
        [HttpPost("[controller]")]
        [Consumes("application/x-www-form-urlencoded")]
        public async Task<IActionResult> GetAccessToken([FromForm] TokenRequest tokenRequest)
        {
            var origin = $"{Request.Scheme}://{Request.Host}";

            return tokenRequest.GrantType switch
            {
                GrantTypes.ClientCredentials => await _clientCredentialsGrantHandler.HandleAsync(tokenRequest, origin),
                GrantTypes.AuthorizationCode => await _authorizationCodeGrantHandler.HandleAsync(tokenRequest, origin),
                _ => await _invalidGrantHandler.HandleAsync(tokenRequest, origin)
            };
        }
    }
}
