namespace OAuthOidc.Models.Errors
{
    public class InvalidClient : ResultBase
    {
        public string Error { get; } = "invalid_client";
    }
}
