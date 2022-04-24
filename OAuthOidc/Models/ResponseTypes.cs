namespace OAuthOidc.Models
{
    public static class ResponseTypes
    {
        public const string Code = "code";
        public const string IdToken = "id_token";
        public const string CodeIdToken = "code id_token";

        public static bool IsResponseTypeValid(this string s)
        {
            if (s.Split(" ").Any(p => p != Code && p != IdToken)) return false;
            return true;
        }
    }
}
