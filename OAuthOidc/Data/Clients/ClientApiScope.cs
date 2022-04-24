using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OAuthOidc.Data.Clients
{
    [Table("ClientApiScopes")]
    public class ClientApiScope
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "API Scope is required")]
        public ApiScope ApiScope { get; set; }
    }
}
