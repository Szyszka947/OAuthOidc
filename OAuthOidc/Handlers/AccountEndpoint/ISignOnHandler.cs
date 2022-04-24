using Microsoft.AspNetCore.Mvc.ModelBinding;
using OAuthOidc.ViewModels;

namespace OAuthOidc.Handlers.AccountEndpoint
{
    public interface ISignOnHandler
    {
        Task<bool> SignOnAsync(SignOnViewModel signOnViewModel, HttpContext httpContext, ModelStateDictionary modelState);
    }
}
