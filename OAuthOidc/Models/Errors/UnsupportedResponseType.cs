namespace OAuthOidc.Models.Errors
{
    public class UnsupportedResponseType : ResultBase
    {
        public string Error { get; } = "unsupported_response_type";
    }
}
