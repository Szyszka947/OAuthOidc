using System.ComponentModel.DataAnnotations;

namespace OAuthOidc.Data
{
    public class Claim
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Claim type is required")]
        [MaxLength(64, ErrorMessage = "The maximum length of the claim type is 64")]
        public string Type { get; set; }
    }
}
