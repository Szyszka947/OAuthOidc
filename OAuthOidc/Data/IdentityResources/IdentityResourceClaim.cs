using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OAuthOidc.Data.IdentityResources
{
    [Table("IdentityResourceClaims")]
    public class IdentityResourceClaim : Claim
    {
    }
}
