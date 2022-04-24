namespace OAuthOidc.Models.Errors
{
    public class InvalidScope : ResultBase
    {
        public string Error { get; } = "invalid_scope";
    }
}
