using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using OAuthOidc.Data;
using OAuthOidc.Data.Users;
using OAuthOidc.Stores;
using OAuthOidc.ViewModels;
using System.Security.Claims;

namespace OAuthOidc.Handlers.AccountEndpoint.Impl
{
    public class SignInHandlerImpl : ISignInHandler
    {
        private readonly IUserStore _userStore;

        public SignInHandlerImpl(IUserStore userStore)
        {
            _userStore = userStore;
        }

        public async Task<bool> SignInAsync(SignInViewModel signInViewModel, HttpContext httpContext)
        {
            var user = await _userStore.FindByEmailAsync(signInViewModel.Email);

            if (user == null || !BCrypt.Net.BCrypt.EnhancedVerify(signInViewModel.Password, user.PasswordHash))
                return false;

            user.Claims.Add(new UserClaim { Type = ClaimTypes.Name, Value = user.Email });
            user.Claims.Add(new UserClaim { Type = ClaimTypes.NameIdentifier, Value = user.Id.ToString() });

            var claimsIdentity = new ClaimsIdentity(user.Claims.Select(p => p.MapToClaim()), CookieAuthenticationDefaults.AuthenticationScheme);

            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

            return true;
        }
    }
}
