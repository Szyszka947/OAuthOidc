using Microsoft.AspNetCore.Mvc;
using OAuthOidc.Models;
using OAuthOidc.Stores;
using OAuthOidc.Validators;
using OAuthOidc.Validators.Impl;

namespace OAuthOidc.Handlers.TokenEndpoint.Impl
{
    public class InvalidGrantHandlerImpl : IInvalidGrantHandler
    {
        private readonly IClientStore _clientStore;
        private readonly IGrantValidator _grantValidator;

        public InvalidGrantHandlerImpl(IClientStore clientStore, ValidationResolver validationResolver)
        {
            _clientStore = clientStore;
            _grantValidator = validationResolver(nameof(ClientCredentialsGrantValidatorImpl));
        }

        public async Task<IActionResult> HandleAsync(TokenRequest tokenRequest, string origin)
        {
            var client = await _clientStore.SingleByIdAsync(tokenRequest.ClientId);

            return new BadRequestObjectResult(await _grantValidator.Validate(tokenRequest, client));
        }
    }
}
