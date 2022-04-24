using System.ComponentModel.DataAnnotations;

namespace OAuthOidc.Data
{
    public class ApiScope
    {
        public int Id { get; set; }
        public bool Enabled { get; set; } = true;

        /// <summary>
        /// Scope name.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "API Scope name is required")]
        [MaxLength(64, ErrorMessage = "The maximum length of the name is 64")]
        public string Name { get; set; }

        /// <summary>
        /// Scope display name for consent screen.
        /// </summary>
        [MaxLength(64, ErrorMessage = "The maximum length of the display name is 64")]
        public string? DisplayName { get; set; }
    }
}
