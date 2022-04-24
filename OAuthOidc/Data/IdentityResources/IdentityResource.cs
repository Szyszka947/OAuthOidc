using System.ComponentModel.DataAnnotations;

namespace OAuthOidc.Data.IdentityResources
{
    public class IdentityResource
    {
        public int Id { get; set; }
        public bool Enabled { get; set; } = true;

        /// <summary>
        /// Identity Resource name
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Identity Resource name is required")]
        [MaxLength(64, ErrorMessage = "The maximum length of the name is 64")]
        public string Name { get; set; }

        /// <summary>
        /// Identity Resource display name for consent screen.
        /// </summary>
        [MaxLength(64, ErrorMessage = "The maximum length of the display name is 64")]
        public string? DisplayName { get; set; }

        /// <summary>
        /// Identity Resource description for consent screen.
        /// </summary>
        [MaxLength(64, ErrorMessage = "The maximum length of the description is 64")]
        public string? Description { get; set; }

        /// <summary>
        /// List of associated user claim types that should be included in the identity token.
        /// </summary>
        public List<IdentityResourceClaim>? Claims { get; set; }
    }
}
