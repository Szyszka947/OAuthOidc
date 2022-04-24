using OAuthOidc.Stores;
using OAuthOidc.Stores.Impl;
using OAuthOidc.Validators;
using OAuthOidc.Validators.Impl;

namespace OAuthOidc.ExtensionMethods
{
    public static class ScopedServicesExtension
    {
        public static void RegisterScopedServices(this IServiceCollection services)
        {
            services.AddScoped<IClientStore, ClientStoreImpl>();
            services.AddScoped<IApiResourcesStore, ApiResourcesStoreImpl>();
            services.AddScoped<IIdentityResourcesStore, IdentityResourcesStoreImpl>();
            services.AddScoped<IScopesStore, ScopesStoreImpl>();
            services.AddScoped<IUserStore, UserStoreImpl>();
            services.AddScoped<IPersistedGrantsStore, PersistedGrantsStoreImpl>();

            services.AddScoped<IAuthorizeRequestValidator, AuthorizeRequestValidatorImpl>();

            services.AddScoped<ClientCredentialsGrantValidatorImpl>();
            services.AddScoped<AuthorizationCodeGrantValidatorImpl>();

            services.AddScoped<ValidationResolver>(serviceProvider => key =>
            {
                return key switch
                {
                    nameof(ClientCredentialsGrantValidatorImpl) => serviceProvider.GetService<ClientCredentialsGrantValidatorImpl>(),
                    nameof(AuthorizationCodeGrantValidatorImpl) => serviceProvider.GetService<AuthorizationCodeGrantValidatorImpl>(),
                    _ => throw new KeyNotFoundException()
                };
            });
        }
    }
}
