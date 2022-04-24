using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OAuthOidc.Data.Users
{
    [Table("UserClaims")]
    public class UserClaim : Claim
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Claim value is required")]
        [MaxLength(64, ErrorMessage = "The maximum length of the claim value is 64")]
        public string Value { get; set; }

        public System.Security.Claims.Claim MapToClaim()
        {
            return new System.Security.Claims.Claim(Type, Value);
        }
    }
}
