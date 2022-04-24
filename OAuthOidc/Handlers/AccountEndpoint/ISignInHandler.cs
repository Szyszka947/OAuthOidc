using OAuthOidc.ViewModels;

namespace OAuthOidc.Handlers.AccountEndpoint
{
    public interface ISignInHandler
    {
        Task<bool> SignInAsync(SignInViewModel signIn, HttpContext httpContext);
    }
}
