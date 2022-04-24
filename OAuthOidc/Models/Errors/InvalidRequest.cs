namespace OAuthOidc.Models.Errors
{
    public class InvalidRequest : ResultBase
    {
        public string Error { get; } = "invalid_request";
    }
}
