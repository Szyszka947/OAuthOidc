namespace OAuthOidc.Models.Errors
{
    public class InvalidGrant : ResultBase
    {
        public string Error { get; } = "invalid_grant";
    }
}
