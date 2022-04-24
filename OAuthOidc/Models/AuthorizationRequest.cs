using Microsoft.AspNetCore.Mvc;

namespace OAuthOidc.Models
{
    public class AuthorizationRequest : Request
    {
        [BindProperty(Name = "client_id")]
        public string? ClientId { get; set; }

        public string? Scope { get; set; }

        [BindProperty(Name = "redirect_uri")]
        public string? RedirectUri { get; set; }

        [BindProperty(Name = "response_type")]
        public string? ResponseType { get; set; }

        public string? State { get; set; }

        public string? Nonce { get; set; }

        [BindProperty(Name = "code_challenge")]
        public string? CodeChallenge { get; set; }

        [BindProperty(Name = "code_challenge_method")]
        public string? CodeChallengeMethod { get; set; } = CodeChallengeMethods.Plain;
    }
}
