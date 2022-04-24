namespace OAuthOidc.Models.Errors
{
    public class InvalidCodeVerifier : ResultBase
    {
        public string Error { get; } = "invalid_code_verifier";
    }
}
