using Microsoft.AspNetCore.Mvc;

namespace OAuthOidc.Models
{
    public class TokenRequest : Request
    {
        [BindProperty(Name = "client_id")]
        public string? ClientId { get; set; }

        [BindProperty(Name = "client_secret")]
        public string? ClientSecret { get; set; }

        [BindProperty(Name = "scope")]
        public string? Scope { get; set; }

        [BindProperty(Name = "grant_type")]
        public string? GrantType { get; set; }

        [BindProperty(Name = "redirect_uri")]
        public string? RedirectUri { get; set; }

        [BindProperty(Name = "code")]
        public string? Code { get; set; }

        [BindProperty(Name = "code_verifier")]
        public string? CodeVerifier { get; set; }

        [BindProperty(Name = "refresh_token")]
        public string? RefreshToken { get; set; }
    }
}
