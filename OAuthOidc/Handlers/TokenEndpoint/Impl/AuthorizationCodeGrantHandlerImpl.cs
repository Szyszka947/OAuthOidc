using Microsoft.AspNetCore.Mvc;
using OAuthOidc.Models;
using OAuthOidc.Services;
using OAuthOidc.Stores;
using OAuthOidc.Validators;
using OAuthOidc.Validators.Impl;

namespace OAuthOidc.Handlers.TokenEndpoint.Impl
{
    public class AuthorizationCodeGrantHandlerImpl : IAuthorizationCodeGrantHandler
    {
        private readonly IClientStore _clientStore;
        private readonly IGrantValidator _grantValidator;
        private readonly IGenerateAccessTokenService _generateAccessTokenService;

        public AuthorizationCodeGrantHandlerImpl(IClientStore clientStore, ValidationResolver validationResolver, IGenerateAccessTokenService generateAccessTokenService)
        {
            _clientStore = clientStore;
            _grantValidator = validationResolver(nameof(AuthorizationCodeGrantValidatorImpl));
            _generateAccessTokenService = generateAccessTokenService;
        }

        public async Task<IActionResult> HandleAsync(TokenRequest tokenRequest, string origin)
        {
            var client = await _clientStore.SingleByIdAsync(tokenRequest.ClientId);

            var initialValidationResult = await _grantValidator.Validate(tokenRequest, client);
            if (initialValidationResult is not null) return new BadRequestObjectResult(initialValidationResult);

            return new OkObjectResult(await _generateAccessTokenService.GenerateAsync(tokenRequest, client, origin, true));
        }
    }
}
