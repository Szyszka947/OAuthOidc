using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OAuthOidc.Data.Clients
{
    [Table("ClientRedirectUris")]
    public class ClientRedirectUri
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Redirect URI is required")]
        [MaxLength(128, ErrorMessage = "The maximum length of the redirect uri is 128")]
        public string RedirectUri { get; set; }
    }
}
