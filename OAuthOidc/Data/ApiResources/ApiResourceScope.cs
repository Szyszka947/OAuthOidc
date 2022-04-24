using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OAuthOidc.Data.ApiResources
{
    [Table("ApiResourceScopes")]
    public class ApiResourceScope
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "API Scope is required")]
        public ApiScope ApiScope { get; set; }
    }
}
