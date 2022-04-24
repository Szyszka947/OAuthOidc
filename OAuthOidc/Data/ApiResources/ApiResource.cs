using OAuthOidc.Validators;
using OAuthOidc.Validators.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace OAuthOidc.Data.ApiResources
{
    public class ApiResource
    {
        public int Id { get; set; }
        public bool Enabled { get; set; } = true;

        /// <summary>
        /// API Resource name
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "API Resource name is required")]
        [MaxLength(64, ErrorMessage = "The maximum length of the name is 64")]
        public string Name { get; set; }

        /// <summary>
        /// API Resource display name for consent screen.
        /// </summary>
        [MaxLength(64, ErrorMessage = "The maximum length of the display name is 64")]
        public string? DisplayName { get; set; }

        /// <summary>
        /// API Resource description for consent screen.
        /// </summary>
        [MaxLength(64, ErrorMessage = "The maximum length of the description is 64")]
        public string? Description { get; set; }

        /// <summary>
        /// API Secrets for introspection endpoint.
        /// </summary>
        public IQueryable<ApiResourceSecret>? ApiSecrets { get; set; }

        /// <summary>
        /// Scopes that give access to the resource.
        /// </summary>
        [NotEmptyList(ErrorMessage = "Scopes are empty")]
        public List<ApiResourceScope> Scopes { get; set; }

        /// <summary>
        /// List of associated user claim types that should be included in the access token.
        /// </summary>
        public List<ApiResourceClaim>? Claims { get; set; }
    }
}
