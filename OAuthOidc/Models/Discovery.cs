using System.Text.Json.Serialization;

namespace OAuthOidc.Models
{
    public class Discovery
    {
        public Discovery(string origin)
        {
            string prefixOAuth = origin + "/api/oauth/v2.1/";
            string prefixOpenid = origin + "/api/openid/v2.0/";

            TokenEndpoint = prefixOAuth + "token";
            PemUri = origin + "/.well-known/openid-configuration/pem";
            Issuer = origin;
            AuthorizationEndpoint = prefixOpenid + "authorize";
        }

        public string Issuer { get; set; }

        [JsonPropertyName("token_endpoint")]
        public string TokenEndpoint { get; set; }

        [JsonPropertyName("pem_uri")]
        public string PemUri { get; set; }

        [JsonPropertyName("authorization_endpoint")]
        public string AuthorizationEndpoint { get; set; }
    }
}
