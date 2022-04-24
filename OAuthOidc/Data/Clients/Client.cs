using OAuthOidc.Validators.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace OAuthOidc.Data.Clients
{
    public class Client
    {
        public int Id { get; set; }
        public bool Enabled { get; set; } = true;

        /// <summary>
        /// This is unique client id.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Client Id is required")]
        [MaxLength(64, ErrorMessage = "The maximum length of the client id is 64")]
        public string ClientId { get; set; }

        /// <summary>
        /// Client name for consent screen.
        /// </summary>
        [MaxLength(64, ErrorMessage = "The maximum length of the client name is 64")]
        public string? ClientName { get; set; }

        /// <summary>
        /// Client's secure secrets.
        /// </summary>
        [NotEmptyList(ErrorMessage = "At least 1 client secret is required")]
        public List<ClientSecret> ClientSecrets { get; set; }

        /// <summary>
        /// Client grant type.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Grant type is required")]
        public string GrantType { get; set; }

        /// <summary>
        /// Client Api Scopes.
        /// </summary>
        [NotEmptyList(ErrorMessage = "At least 1 client scope is required")]
        public List<ClientApiScope> ApiScopes { get; set; }

        public List<ClientIdentityScope> IdentityScopes { get; set; }

        /// <summary>
        /// Client description.
        /// </summary>
        [MaxLength(64, ErrorMessage = "The maximum length of the description is 64")]
        public string? Description { get; set; }

        /// <summary>
        /// Client logo uri for consent screen.
        /// </summary>
        [MaxLength(128, ErrorMessage = "The maximum length of the logo uri is 128")]
        public string? LogoUri { get; set; }

        /// <summary>
        /// Client redirect uris.
        /// </summary>
        public List<ClientRedirectUri>? RedirectUris { get; set; }

        /// <summary>
        /// Lifetime of the access token in seconds (defaults to 1800s / 30min).
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessage = "Access Token Lifetime must be in the range of 1 - int max value")]
        public int AccessTokenLifetime { get; set; } = 1800;


        /// <summary>
        /// Lifetime of the authorization code in seconds (defaults to 300s / 5min).
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessage = "Access Token Lifetime must be in the range of 1 - int max value")]
        public int AuthorizationCodeLifetime { get; set; } = 300;

        /// <summary>
        /// Lifetime of the refresh token in seconds (defaults to 2592000 seconds / 30 days).
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessage = "Refresh Token Lifetime must be in the range of 1 - int max value")]
        public int RefreshTokenLifetime { get; set; } = 2592000;
    }
}
