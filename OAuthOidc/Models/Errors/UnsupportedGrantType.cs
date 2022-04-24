namespace OAuthOidc.Models.Errors
{
    public class UnsupportedGrantType : ResultBase
    {
        public string Error { get; } = "unsupported_grant_type";
    }
}
