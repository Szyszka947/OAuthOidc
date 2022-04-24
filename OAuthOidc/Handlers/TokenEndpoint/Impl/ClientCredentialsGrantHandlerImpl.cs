using Microsoft.AspNetCore.Mvc;
using OAuthOidc.Models;
using OAuthOidc.Services;
using OAuthOidc.Stores;
using OAuthOidc.Validators;
using OAuthOidc.Validators.Impl;

namespace OAuthOidc.Handlers.TokenEndpoint.Impl
{
    public class ClientCredentialsGrantHandlerImpl : IClientCredentialsGrantHandler
    {
        private readonly IGenerateAccessTokenService _generateAccessTokenService;
        private readonly IClientStore _clientStore;
        private readonly IGrantValidator _grantValidator;

        public ClientCredentialsGrantHandlerImpl(IGenerateAccessTokenService generateAccessTokenService, IClientStore clientStore,
            ValidationResolver validationResolver)
        {
            _generateAccessTokenService = generateAccessTokenService;
            _clientStore = clientStore;
            _grantValidator = validationResolver(nameof(ClientCredentialsGrantValidatorImpl));
        }

        public async Task<IActionResult> HandleAsync(TokenRequest tokenRequest, string origin)
        {
            var client = await _clientStore.SingleByIdAsync(tokenRequest.ClientId);

            var initialValidationResult = await _grantValidator.Validate(tokenRequest, client);
            if (initialValidationResult is not null) return new BadRequestObjectResult(initialValidationResult);

            return new OkObjectResult(await _generateAccessTokenService.GenerateAsync(tokenRequest, client, origin, false));
        }
    }
}
