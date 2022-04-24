using Microsoft.AspNetCore.Mvc;
using OAuthOidc.Models;
using OAuthOidc.Services;
using OAuthOidc.Stores;
using OAuthOidc.Validators;

namespace OAuthOidc.Handlers.AuthorizationEndpoint.Impl
{
    public class AuthorizeHandlerImpl : IAuthorizeHandler
    {
        private readonly IClientStore _clientStore;
        private readonly IUserStore _userStore;
        private readonly IAuthorizeRequestValidator _authorizeRequestValidator;
        private readonly IGenerateAuthorizationCodeService _generateAuthorizationCodeService;

        public AuthorizeHandlerImpl(IClientStore clientStore, IAuthorizeRequestValidator authorizeRequestValidator,
            IGenerateAuthorizationCodeService generateAuthorizationCodeService, IUserStore userStore)
        {
            _clientStore = clientStore;
            _authorizeRequestValidator = authorizeRequestValidator;
            _generateAuthorizationCodeService = generateAuthorizationCodeService;
            _userStore = userStore;
        }

        public async Task<(IActionResult, string)> HandleAsync(AuthorizationRequest authorizationRequest, string email)
        {
            var client = await _clientStore.SingleByIdAsync(authorizationRequest.ClientId);
            var user = await _userStore.FindByEmailAsync(email);

            var initialValidationResult = _authorizeRequestValidator.Validate(authorizationRequest, client);
            if (initialValidationResult is not null) return (new BadRequestObjectResult(initialValidationResult), null);

            if (email is null) return (null, null);

            var authorizationCode = await _generateAuthorizationCodeService.GenerateAsync(
                authorizationRequest.ClientId,
                authorizationRequest.CodeChallenge,
                authorizationRequest.CodeChallengeMethod,
                authorizationRequest.Scope.Split(" ").ToList(),
                authorizationRequest.RedirectUri,
                user.Id);

            return (null, authorizationCode);
        }
    }
}
