using Microsoft.AspNetCore.Mvc.ModelBinding;
using OAuthOidc.Stores;
using OAuthOidc.ViewModels;

namespace OAuthOidc.Handlers.AccountEndpoint.Impl
{
    public class SignOnHandlerImpl : ISignOnHandler
    {
        private readonly IUserStore _userStore;

        public SignOnHandlerImpl(IUserStore userStore)
        {
            _userStore = userStore;
        }

        public async Task<bool> SignOnAsync(SignOnViewModel signOnViewModel, HttpContext httpContext, ModelStateDictionary modelState)
        {
            var emailIsTaken = await _userStore.FindByEmailAsync(signOnViewModel.Email) != default;
            if (emailIsTaken) { modelState.AddModelError("email", "Invalid e-mail address syntax or e-mail is taken"); return false; }
            if (!modelState.IsValid) return false;

            await _userStore.CreateAsync(signOnViewModel);
            return true;
        }
    }
}
