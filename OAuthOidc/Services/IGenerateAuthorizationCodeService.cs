namespace OAuthOidc.Services
{
    public interface IGenerateAuthorizationCodeService
    {
        Task<string> GenerateAsync(string clientId, string codeChallenge, string codeChallengeMethod, List<string> requestedScopes, string redirectUri, int userId);
    }
}
