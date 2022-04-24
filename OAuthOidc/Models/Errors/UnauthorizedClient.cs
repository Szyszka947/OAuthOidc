namespace OAuthOidc.Models.Errors
{
    public class UnauthorizedClient : ResultBase
    {
        public string Error { get; } = "unauthorized_client";
    }
}
