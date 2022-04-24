namespace OAuthOidc.Models
{
    public static class GrantTypes
    {
        public const string AuthorizationCode = "authorization_code";
        public const string RefreshToken = "refresh_token";
        public const string ClientCredentials = "client_credentials";

        /// <summary>
        /// Check string is valid grant type.
        /// </summary>
        /// <param name="grantType">Grant Type</param>
        /// <returns>Returns true if valid, otherwise false</returns>
        public static bool IsGrantTypeValid(this string grantType)
        {
            if (grantType != AuthorizationCode && grantType != RefreshToken && grantType != ClientCredentials)
                return false;

            return true;
        }
    }
}
