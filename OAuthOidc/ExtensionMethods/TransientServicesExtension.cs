using OAuthOidc.Handlers.AccountEndpoint;
using OAuthOidc.Handlers.AccountEndpoint.Impl;
using OAuthOidc.Handlers.AuthorizationEndpoint;
using OAuthOidc.Handlers.AuthorizationEndpoint.Impl;
using OAuthOidc.Handlers.TokenEndpoint;
using OAuthOidc.Handlers.TokenEndpoint.Impl;
using OAuthOidc.Services;
using OAuthOidc.Services.Impl;

namespace OAuthOidc.ExtensionMethods
{
    public static class TransientServicesExtension
    {
        public static void RegisterTransientServices(this IServiceCollection services)
        {
            services.AddTransient<IClientCredentialsGrantHandler, ClientCredentialsGrantHandlerImpl>();
            services.AddTransient<IAuthorizationCodeGrantHandler, AuthorizationCodeGrantHandlerImpl>();
            services.AddTransient<IInvalidGrantHandler, InvalidGrantHandlerImpl>();
            services.AddTransient<IGenerateAccessTokenService, GenerateAccessTokenServiceImpl>();
            services.AddTransient<IAuthorizeHandler, AuthorizeHandlerImpl>();

            services.AddTransient<ISignInHandler, SignInHandlerImpl>();
            services.AddTransient<ISignOnHandler, SignOnHandlerImpl>();

            services.AddTransient<IGenerateAuthorizationCodeService, GenerateAuthorizationCodeServiceImpl>();
        }
    }
}
