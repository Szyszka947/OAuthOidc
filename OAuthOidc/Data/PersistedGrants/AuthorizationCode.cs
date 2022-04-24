using OAuthOidc.Data.Users;

namespace OAuthOidc.Data.PersistedGrants
{
    public class AuthorizationCode
    {
        public string ClientId { get; set; }
        public string RedirectUri { get; set; }
        public string CreatedAt { get; set; }
        public List<string> Scopes { get; set; }
        public string CodeChallenge { get; set; }
        public string CodeChallengeMethod { get; set; }
        public List<UserClaim> Claims { get; set; }
    }
}
