using OAuthOidc.Data.IdentityResources;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OAuthOidc.Data.Clients
{
    [Table("ClientIdentityScopes")]
    public class ClientIdentityScope
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Identity Resource is required")]
        public IdentityResource IdentityResource { get; set; }
    }
}
