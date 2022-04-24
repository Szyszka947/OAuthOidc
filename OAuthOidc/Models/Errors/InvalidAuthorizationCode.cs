namespace OAuthOidc.Models.Errors
{
    public class InvalidAuthorizationCode : ResultBase
    {
        public string Error { get; } = "invalid_authorization_code";
    }
}
