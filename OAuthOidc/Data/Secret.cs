using System.ComponentModel.DataAnnotations;

namespace OAuthOidc.Data
{
    public class Secret
    {
        public int Id { get; set; }
        /// <summary>
        /// Secret value
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Value is required")]
        public byte[] Value { get; set; }
    }
}
