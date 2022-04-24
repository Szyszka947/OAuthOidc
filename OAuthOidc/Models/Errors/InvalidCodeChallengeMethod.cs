namespace OAuthOidc.Models.Errors
{
    public class InvalidCodeChallengeMethod : ResultBase
    {
        public string Error { get; } = "invalid_code_challenge_method";
    }
}
